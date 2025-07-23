using RegisterAPII.DTOs;

namespace RegisterAPII.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationResponseDto> CreateNotificationAsync(NotificationDto notificationDto, int fromAccountId);
        Task<bool> MarkAsReadAsync(int notificationId, int accountId);
        Task<List<NotificationResponseDto>> GetNotificationsByAccountIdAsync(int accountId);
        Task<List<NotificationResponseDto>> GetUnreadNotificationsByAccountIdAsync(int accountId);
        Task<int> GetUnreadCountAsync(int accountId);
        Task SendNoteNotificationAsync(int noteId, int createdByAccountId);
        Task SendReportNotificationAsync(int reportId, int createdByAccountId);
        Task SendReportApprovalNotificationAsync(int reportId, int reviewedByAccountId);
    }
}