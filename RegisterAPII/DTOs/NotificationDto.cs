using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class NotificationDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public string Type { get; set; } // "Note", "Report", "General"
        
        [Required]
        public int ToAccountId { get; set; }
        
        public int? RelatedEntityId { get; set; }
        public string? RelatedEntityType { get; set; }
    }

    public class NotificationResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int FromAccountId { get; set; }
        public string FromAccountName { get; set; }
        public int ToAccountId { get; set; }
        public string ToAccountName { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? RelatedEntityType { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}