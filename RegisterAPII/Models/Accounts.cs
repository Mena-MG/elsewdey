    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RegisterAPII.Models
{
    public class Accounts
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(14)]
        public string NationalID { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int LoginId { get; set; }
        public LoginAccount LoginAccount { get; set; }
    }
}