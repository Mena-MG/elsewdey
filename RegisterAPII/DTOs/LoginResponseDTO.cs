using RegisterAPII.Models;

namespace RegisterAPII.DTOs
{
    public class LoginResponseDTO
    {
        public class LoginResponseDto
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public string? Token { get; set; } // Nullable in case of failure
            public Accounts? User { get; set; } 
        }
    }
}
