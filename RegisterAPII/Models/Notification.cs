using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.Models
{
    public class Notification
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public string Type { get; set; } // "Note", "Report", "General"
        
        public int FromAccountId { get; set; }
        public Accounts FromAccount { get; set; }
        
        public int ToAccountId { get; set; }
        public Accounts ToAccount { get; set; }
        
        public int? RelatedEntityId { get; set; } // ID of related note, report, etc.
        public string? RelatedEntityType { get; set; } // "Note", "Report"
        
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReadAt { get; set; }
    }
}