using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.Models
{
    public class LoginAccount
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required , MaxLength(14)]
        public string NationalID { get; set; }
        public int AccountId { get; set; }
        public Accounts Accounts { get; set; }
    }
}