using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;

namespace RegisterAPII.Repos
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReportResponseDto> CreateReportAsync(ReportDto reportDto, int createdByAccountId)
        {
            var report = new Report
            {
                Title = reportDto.Title,
                Content = reportDto.Content,
                Type = reportDto.Type,
                StudentProfileId = reportDto.StudentProfileId,
                CreatedByAccountId = createdByAccountId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // TODO: Send notification to admin for review (implement notification sending separately)
            // await _notificationService.SendReportNotificationAsync(report.Id, createdByAccountId);

            return await GetReportByIdAsync(report.Id);
        }

        public async Task<ReportResponseDto> ReviewReportAsync(int reportId, ReviewReportDto reviewDto, int reviewedByAccountId)
        {
            var report = await _context.Reports.FindAsync(reportId);
            if (report == null)
                throw new ArgumentException("Report not found");

            if (report.Status != "Pending")
                throw new InvalidOperationException("Report has already been reviewed");

            report.Status = reviewDto.Status;
            report.AdminComments = reviewDto.AdminComments;
            report.ReviewedByAccountId = reviewedByAccountId;
            report.ReviewedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // TODO: If approved, send notification to parent (implement notification sending separately)
            // if (reviewDto.Status == "Approved")
            // {
            //     await _notificationService.SendReportApprovalNotificationAsync(reportId, reviewedByAccountId);
            // }

            return await GetReportByIdAsync(reportId);
        }

        public async Task<ReportResponseDto?> GetReportByIdAsync(int reportId)
        {
            var report = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.CreatedBy)
                .Include(r => r.ReviewedBy)
                .FirstOrDefaultAsync(r => r.Id == reportId && r.IsActive);

            if (report == null)
                return null;

            return new ReportResponseDto
            {
                Id = report.Id,
                Title = report.Title,
                Content = report.Content,
                Type = report.Type,
                StudentProfileId = report.StudentProfileId,
                StudentName = report.StudentProfile.Name ?? "",
                CreatedByAccountId = report.CreatedByAccountId,
                CreatedByName = report.CreatedBy.FullName,
                ReviewedByAccountId = report.ReviewedByAccountId,
                ReviewedByName = report.ReviewedBy?.FullName,
                Status = report.Status,
                AdminComments = report.AdminComments,
                CreatedAt = report.CreatedAt,
                ReviewedAt = report.ReviewedAt,
                IsActive = report.IsActive
            };
        }

        public async Task<List<ReportResponseDto>> GetReportsByStudentIdAsync(int studentId)
        {
            var reports = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.CreatedBy)
                .Include(r => r.ReviewedBy)
                .Where(r => r.StudentProfileId == studentId && r.IsActive)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return reports.Select(MapToResponseDto).ToList();
        }

        public async Task<List<ReportResponseDto>> GetPendingReportsAsync()
        {
            var reports = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.CreatedBy)
                .Include(r => r.ReviewedBy)
                .Where(r => r.Status == "Pending" && r.IsActive)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return reports.Select(MapToResponseDto).ToList();
        }

        public async Task<List<ReportResponseDto>> GetReportsByCreatorAsync(int createdByAccountId)
        {
            var reports = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.CreatedBy)
                .Include(r => r.ReviewedBy)
                .Where(r => r.CreatedByAccountId == createdByAccountId && r.IsActive)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return reports.Select(MapToResponseDto).ToList();
        }

        public async Task<List<ReportResponseDto>> GetReportsByStatusAsync(string status)
        {
            var reports = await _context.Reports
                .Include(r => r.StudentProfile)
                .Include(r => r.CreatedBy)
                .Include(r => r.ReviewedBy)
                .Where(r => r.Status == status && r.IsActive)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return reports.Select(MapToResponseDto).ToList();
        }

        private ReportResponseDto MapToResponseDto(Report report)
        {
            return new ReportResponseDto
            {
                Id = report.Id,
                Title = report.Title,
                Content = report.Content,
                Type = report.Type,
                StudentProfileId = report.StudentProfileId,
                StudentName = report.StudentProfile.Name ?? "",
                CreatedByAccountId = report.CreatedByAccountId,
                CreatedByName = report.CreatedBy.FullName,
                ReviewedByAccountId = report.ReviewedByAccountId,
                ReviewedByName = report.ReviewedBy?.FullName,
                Status = report.Status,
                AdminComments = report.AdminComments,
                CreatedAt = report.CreatedAt,
                ReviewedAt = report.ReviewedAt,
                IsActive = report.IsActive
            };
        }
    }
}