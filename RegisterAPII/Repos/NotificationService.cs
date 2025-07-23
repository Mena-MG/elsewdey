using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;

namespace RegisterAPII.Repos
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NotificationResponseDto> CreateNotificationAsync(NotificationDto notificationDto, int fromAccountId)
        {
            var notification = new Notification
            {
                Title = notificationDto.Title,
                Message = notificationDto.Message,
                Type = notificationDto.Type,
                FromAccountId = fromAccountId,
                ToAccountId = notificationDto.ToAccountId,
                RelatedEntityId = notificationDto.RelatedEntityId,
                RelatedEntityType = notificationDto.RelatedEntityType,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return await GetNotificationByIdAsync(notification.Id);
        }

        public async Task<bool> MarkAsReadAsync(int notificationId, int accountId)
        {
            var notification = await _context.Notifications
                .FirstOrDefaultAsync(n => n.Id == notificationId && n.ToAccountId == accountId);

            if (notification == null)
                return false;

            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<NotificationResponseDto>> GetNotificationsByAccountIdAsync(int accountId)
        {
            var notifications = await _context.Notifications
                .Include(n => n.FromAccount)
                .Include(n => n.ToAccount)
                .Where(n => n.ToAccountId == accountId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notifications.Select(MapToResponseDto).ToList();
        }

        public async Task<List<NotificationResponseDto>> GetUnreadNotificationsByAccountIdAsync(int accountId)
        {
            var notifications = await _context.Notifications
                .Include(n => n.FromAccount)
                .Include(n => n.ToAccount)
                .Where(n => n.ToAccountId == accountId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notifications.Select(MapToResponseDto).ToList();
        }

        public async Task<int> GetUnreadCountAsync(int accountId)
        {
            return await _context.Notifications
                .CountAsync(n => n.ToAccountId == accountId && !n.IsRead);
        }

        public async Task SendNoteNotificationAsync(int noteId, int createdByAccountId)
        {
            var note = await _context.Notes
                .Include(n => n.StudentProfile)
                .Include(n => n.CreatedBy)
                .FirstOrDefaultAsync(n => n.Id == noteId);

            if (note == null) return;

            // Get SuperAdmin and Specialist accounts
            var recipientRoles = new[] { "SuperAdmin", "Specialist" };
            var recipients = await _context.Accounts
                .Include(a => a.Role)
                .Where(a => recipientRoles.Contains(a.Role.Name) && a.IsActive && a.Id != createdByAccountId)
                .ToListAsync();

            foreach (var recipient in recipients)
            {
                var notification = new Notification
                {
                    Title = $"New {note.Type} Note Added",
                    Message = $"A new {note.Type.ToLower()} note has been added for student {note.StudentProfile.Name} by {note.CreatedBy.FullName}",
                    Type = "Note",
                    FromAccountId = createdByAccountId,
                    ToAccountId = recipient.Id,
                    RelatedEntityId = noteId,
                    RelatedEntityType = "Note",
                    CreatedAt = DateTime.UtcNow
                };

                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SendReportNotificationAsync(int reportId, int createdByAccountId)
        {
            var report = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.CreatedBy)
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null) return;

            // Send notification to Admin for review
            var adminAccounts = await _context.Accounts
                .Include(a => a.Role)
                .Where(a => a.Role.Name == "Admin" && a.IsActive)
                .ToListAsync();

            foreach (var admin in adminAccounts)
            {
                var notification = new Notification
                {
                    Title = "New Report Submitted for Review",
                    Message = $"A new {report.Type.ToLower()} report has been submitted for student {report.StudentProfile.Name} by {report.CreatedBy.FullName}",
                    Type = "Report",
                    FromAccountId = createdByAccountId,
                    ToAccountId = admin.Id,
                    RelatedEntityId = reportId,
                    RelatedEntityType = "Report",
                    CreatedAt = DateTime.UtcNow
                };

                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SendReportApprovalNotificationAsync(int reportId, int reviewedByAccountId)
        {
            var report = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.ReviewedBy)
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null || report.Status != "Approved") return;

            // Find parent account (assuming parent role exists)
            // For now, we'll send to SuperAdmin as a placeholder
            var parentAccounts = await _context.Accounts
                .Include(a => a.Role)
                .Where(a => a.Role.Name == "Parent" && a.IsActive)
                .ToListAsync();

            foreach (var parent in parentAccounts)
            {
                var notification = new Notification
                {
                    Title = "Report Approved - Action Required",
                    Message = $"A report for student {report.StudentProfile.Name} has been approved and requires your attention",
                    Type = "Report",
                    FromAccountId = reviewedByAccountId,
                    ToAccountId = parent.Id,
                    RelatedEntityId = reportId,
                    RelatedEntityType = "Report",
                    CreatedAt = DateTime.UtcNow
                };

                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
        }

        private async Task<NotificationResponseDto> GetNotificationByIdAsync(int notificationId)
        {
            var notification = await _context.Notifications
                .Include(n => n.FromAccount)
                .Include(n => n.ToAccount)
                .FirstOrDefaultAsync(n => n.Id == notificationId);

            return MapToResponseDto(notification);
        }

        private NotificationResponseDto MapToResponseDto(Notification notification)
        {
            return new NotificationResponseDto
            {
                Id = notification.Id,
                Title = notification.Title,
                Message = notification.Message,
                Type = notification.Type,
                FromAccountId = notification.FromAccountId,
                FromAccountName = notification.FromAccount.FullName,
                ToAccountId = notification.ToAccountId,
                ToAccountName = notification.ToAccount.FullName,
                RelatedEntityId = notification.RelatedEntityId,
                RelatedEntityType = notification.RelatedEntityType,
                IsRead = notification.IsRead,
                CreatedAt = notification.CreatedAt,
                ReadAt = notification.ReadAt
            };
        }
    }
}