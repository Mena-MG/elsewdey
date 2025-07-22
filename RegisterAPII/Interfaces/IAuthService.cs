using RegisterAPII.DTOs;
using RegisterAPII.Models;

namespace RegisterAPII.Interfaces
{
    public interface IAuthService
    {
        Task<object> CheckUserAsync(string fullName, string nationalId);
        Task<string?> ForgotPasswordAsync(ForgotPasswordDto dto);
        Task<string?> ResetPasswordAsync(string token, ResetPasswordDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}