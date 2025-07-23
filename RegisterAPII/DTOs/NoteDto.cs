using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class NoteDto
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public string Type { get; set; } // "Good" or "Bad"
        
        [Required]
        public int StudentProfileId { get; set; }
    }

    public class NoteResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public int StudentProfileId { get; set; }
        public string StudentName { get; set; }
        public int CreatedByAccountId { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateNoteDto
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public string Type { get; set; } // "Good" or "Bad"
    }
}