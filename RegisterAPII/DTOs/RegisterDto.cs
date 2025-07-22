using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(14)]
        public string NationalID { get; set; }

        [Required, MinLength(5)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$")]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; } // Add this line to pick the Role
    }

}