using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class ReportDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public string Type { get; set; } // "Behavioral", "Academic"
        
        [Required]
        public int StudentProfileId { get; set; }
    }

    public class ReportResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public int StudentProfileId { get; set; }
        public string StudentName { get; set; }
        public int CreatedByAccountId { get; set; }
        public string CreatedByName { get; set; }
        public int? ReviewedByAccountId { get; set; }
        public string? ReviewedByName { get; set; }
        public string Status { get; set; }
        public string? AdminComments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class ReviewReportDto
    {
        [Required]
        public string Status { get; set; } // "Approved", "Rejected"
        
        public string? AdminComments { get; set; }
    }
}