using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }

        public int Age { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public int DaysAbsent { get; set; }

        public string? GoodNotesJson { get; set; } // تخزين كـ JSON

        public string? BadNotesJson { get; set; } // تخزين كـ JSON

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ClassId { get; set; }
        public ClassRoom Class { get; set; }
    }
}
