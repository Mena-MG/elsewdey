using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;

namespace RegisterAPII.Repos
{
    public class StaffManagementService : IStaffManagementService
    {
        private readonly ApplicationDbContext _context;

        public StaffManagementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StaffResponseDto> CreateStaffAsync(CreateStaffDto createStaffDto)
        {
            // Check if email or national ID already exists
            var existingAccount = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Email == createStaffDto.Email || a.NationalID == createStaffDto.NationalID);

            if (existingAccount != null)
                throw new InvalidOperationException("An account with this email or national ID already exists");

            // Create LoginAccount first
            var loginAccount = new LoginAccount
            {
                Email = createStaffDto.Email,
                NationalID = createStaffDto.NationalID,
                Password = "" // Empty password - user will need to set it
            };

            _context.LoginAccounts.Add(loginAccount);
            await _context.SaveChangesAsync();

            // Create Account
            var account = new Accounts
            {
                FullName = createStaffDto.FullName,
                Email = createStaffDto.Email,
                NationalID = createStaffDto.NationalID,
                PasswordHash = "", // Empty password hash
                RoleId = createStaffDto.RoleId,
                LoginId = loginAccount.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            // Update LoginAccount with AccountId
            loginAccount.AccountId = account.Id;
            await _context.SaveChangesAsync();

            return await GetStaffByIdAsync(account.Id);
        }

        public async Task<StaffResponseDto> UpdateStaffAsync(int staffId, UpdateStaffDto updateStaffDto)
        {
            var account = await _context.Accounts
                .Include(a => a.LoginAccount)
                .FirstOrDefaultAsync(a => a.Id == staffId);

            if (account == null)
                throw new ArgumentException("Staff member not found");

            // Check if email is being changed and if it already exists
            if (account.Email != updateStaffDto.Email)
            {
                var existingAccount = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.Email == updateStaffDto.Email && a.Id != staffId);

                if (existingAccount != null)
                    throw new InvalidOperationException("An account with this email already exists");
            }

            // Update Account
            account.FullName = updateStaffDto.FullName;
            account.Email = updateStaffDto.Email;
            account.RoleId = updateStaffDto.RoleId;
            account.IsActive = updateStaffDto.IsActive;

            // Update LoginAccount
            account.LoginAccount.Email = updateStaffDto.Email;

            await _context.SaveChangesAsync();

            return await GetStaffByIdAsync(staffId);
        }

        public async Task<bool> DeleteStaffAsync(int staffId)
        {
            var account = await _context.Accounts.FindAsync(staffId);
            if (account == null)
                return false;

            account.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<StaffResponseDto?> GetStaffByIdAsync(int staffId)
        {
            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.Id == staffId);

            if (account == null)
                return null;

            return new StaffResponseDto
            {
                Id = account.Id,
                FullName = account.FullName,
                Email = account.Email,
                NationalID = account.NationalID,
                RoleId = account.RoleId,
                RoleName = account.Role.Name,
                IsActive = account.IsActive,
                CreatedAt = account.CreatedAt
            };
        }

        public async Task<List<StaffResponseDto>> GetAllStaffAsync()
        {
            var accounts = await _context.Accounts
                .Include(a => a.Role)
                .Where(a => a.Role.Name != "Student" && a.Role.Name != "Parent") // Exclude students and parents
                .OrderBy(a => a.FullName)
                .ToListAsync();

            return accounts.Select(account => new StaffResponseDto
            {
                Id = account.Id,
                FullName = account.FullName,
                Email = account.Email,
                NationalID = account.NationalID,
                RoleId = account.RoleId,
                RoleName = account.Role.Name,
                IsActive = account.IsActive,
                CreatedAt = account.CreatedAt
            }).ToList();
        }

        public async Task<List<StaffResponseDto>> GetStaffByRoleAsync(int roleId)
        {
            var accounts = await _context.Accounts
                .Include(a => a.Role)
                .Where(a => a.RoleId == roleId)
                .OrderBy(a => a.FullName)
                .ToListAsync();

            return accounts.Select(account => new StaffResponseDto
            {
                Id = account.Id,
                FullName = account.FullName,
                Email = account.Email,
                NationalID = account.NationalID,
                RoleId = account.RoleId,
                RoleName = account.Role.Name,
                IsActive = account.IsActive,
                CreatedAt = account.CreatedAt
            }).ToList();
        }

        public async Task<bool> ActivateStaffAsync(int staffId)
        {
            var account = await _context.Accounts.FindAsync(staffId);
            if (account == null)
                return false;

            account.IsActive = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeactivateStaffAsync(int staffId)
        {
            var account = await _context.Accounts.FindAsync(staffId);
            if (account == null)
                return false;

            account.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}