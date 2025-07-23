using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.DTOs
{
    public class CreateStaffDto
    {
        [Required]
        public string FullName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string NationalID { get; set; }
        
        [Required]
        public int RoleId { get; set; }
        
        public string? Specialization { get; set; }
    }

    public class UpdateStaffDto
    {
        [Required]
        public string FullName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public int RoleId { get; set; }
        
        public string? Specialization { get; set; }
        
        public bool IsActive { get; set; }
    }

    public class StaffResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? Specialization { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}