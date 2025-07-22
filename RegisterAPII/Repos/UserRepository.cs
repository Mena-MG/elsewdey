using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;

namespace RegisterAPII.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Accounts?> GetUserByEmailAsync(string email)
        {
            return await _context.Accounts
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<Accounts?> GetUserByResetTokenAsync(string token)
        {
            return await _context.Accounts.FirstOrDefaultAsync(u => u.ResetToken == token && u.ResetTokenExpiry > DateTime.UtcNow);
        }

        public async Task AddUserAsync(Accounts user)
        {
            await _context.Accounts.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
    }

}