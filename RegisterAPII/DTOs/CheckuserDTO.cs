using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class CheckuserDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required, MaxLength(14)]
        public string NationalID { get; set; }
    }
}