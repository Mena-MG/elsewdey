using RegisterAPII.Models;

namespace RegisterAPII.Interfaces
{
    public interface IUserRepository
    {
        Task<Accounts?> GetUserByEmailAsync(string email);
        Task<Accounts?> GetUserByResetTokenAsync(string token); 
        Task AddUserAsync(Accounts user);
        Task SaveChangesAsync();
        Task<Role?> GetRoleByIdAsync(int id);

    }
}
