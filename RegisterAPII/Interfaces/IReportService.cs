using RegisterAPII.DTOs;

namespace RegisterAPII.Interfaces
{
    public interface IReportService
    {
        Task<ReportResponseDto> CreateReportAsync(ReportDto reportDto, int createdByAccountId);
        Task<ReportResponseDto> ReviewReportAsync(int reportId, ReviewReportDto reviewDto, int reviewedByAccountId);
        Task<ReportResponseDto?> GetReportByIdAsync(int reportId);
        Task<List<ReportResponseDto>> GetReportsByStudentIdAsync(int studentId);
        Task<List<ReportResponseDto>> GetPendingReportsAsync();
        Task<List<ReportResponseDto>> GetReportsByCreatorAsync(int createdByAccountId);
        Task<List<ReportResponseDto>> GetReportsByStatusAsync(string status);
    }
}