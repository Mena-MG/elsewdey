using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class StudentProfileDto
    {
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int DaysAbsent { get; set; }

        public List<string> GoodNotes { get; set; } = new();

        public List<string> BadNotes { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public int ClassId { get; set; }
    }
}
