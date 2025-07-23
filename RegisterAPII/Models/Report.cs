using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.Models
{
    public class Report
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public string Type { get; set; } // "Behavioral", "Academic"
        
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }
        
        public int CreatedByAccountId { get; set; }
        public Accounts CreatedBy { get; set; }
        
        public int? ReviewedByAccountId { get; set; }
        public Accounts? ReviewedBy { get; set; }
        
        public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"
        
        public string? AdminComments { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewedAt { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}