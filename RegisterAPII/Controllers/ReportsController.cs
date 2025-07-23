using Microsoft.AspNetCore.Mvc;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using System.Security.Claims;

namespace RegisterAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportDto reportDto)
        {
            try
            {
                var createdByAccountId = GetCurrentUserId();
                var result = await _reportService.CreateReportAsync(reportDto, createdByAccountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/review")]
        public async Task<IActionResult> ReviewReport(int id, [FromBody] ReviewReportDto reviewDto)
        {
            try
            {
                var reviewedByAccountId = GetCurrentUserId();
                var result = await _reportService.ReviewReportAsync(id, reviewDto, reviewedByAccountId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport(int id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetReportsByStudent(int studentId)
        {
            var reports = await _reportService.GetReportsByStudentIdAsync(studentId);
            return Ok(reports);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingReports()
        {
            var reports = await _reportService.GetPendingReportsAsync();
            return Ok(reports);
        }

        [HttpGet("my-reports")]
        public async Task<IActionResult> GetMyReports()
        {
            var createdByAccountId = GetCurrentUserId();
            var reports = await _reportService.GetReportsByCreatorAsync(createdByAccountId);
            return Ok(reports);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetReportsByStatus(string status)
        {
            var reports = await _reportService.GetReportsByStatusAsync(status);
            return Ok(reports);
        }

        private int GetCurrentUserId()
        {
            // In a real application, extract from JWT token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            
            // Placeholder - in production, this should throw an exception or handle authentication properly
            return 1; // Default to first user for testing
        }
    }
}