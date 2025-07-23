using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.Models
{
    public class Note
    {
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public string Type { get; set; } // "Good" or "Bad"
        
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }
        
        public int CreatedByAccountId { get; set; }
        public Accounts CreatedBy { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}