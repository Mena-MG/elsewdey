// --- File: Repos/AuthService.cs ---

using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RegisterAPII.Repos
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly EmailService _emailService;
        private readonly ApplicationDbContext _context;

        public AuthService(IUserRepository userRepository, IJwtService jwtService, EmailService emailService , ApplicationDbContext dbContext)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _emailService = emailService;
            _context = dbContext;
        }


        public async Task<object> CheckUserAsync(string fullName, string nationalId)
        {
            var login = await _context.LoginAccounts
                .Include(l => l.Accounts)
                .FirstOrDefaultAsync(l => l.NationalID == nationalId && l.Accounts.FullName == fullName);

            if (login != null)
            {
                return new
                {
                    Status = "LoginAccountExists",
                    FullName = login.Accounts.FullName,
                    Email = login.Email,
                    Password = login.Password
                };
            }
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.NationalID == nationalId && a.FullName == fullName);

            if (account != null)
            {
                var loginExists = await _context.LoginAccounts.AnyAsync(l => l.AccountId == account.Id);

                if (!loginExists)
                {
                    var generatedEmail = GenerateEmail(account.FullName, account.NationalID);

                    if (string.IsNullOrEmpty(account.Email))
                    {
                        account.Email = generatedEmail;
                        await _context.SaveChangesAsync();
                    }

                    return new
                    {
                        Status = "AccountExistsNoLogin",
                        Email = account.Email
                    };
                }

                return new
                {
                    Status = "AccountExists",
                    Email = account.Email
                };
            }

            return new
            {
                Status = "NotFound"
            };
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Accounts
                .FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower());

            if (user == null)
                return "Email not registered.";

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                return "Incorrect password.";

            // Generate JWT Token
            var token = _jwtService.GenerateToken(user);
            return token;
        }

        private string GenerateEmail(string fullName, string nationalId)
        {
            var names = fullName.Trim().ToLower().Split(' ');

            var first = names.Length > 0 ? names[0] : "user";
            var second = names.Length > 1 ? names[1] : "name";

            var last6 = nationalId.Length >= 6 ? nationalId.Substring(nationalId.Length - 6) : "000000";

            return $"{first}.{second}.{last6}@gmail.com";
        }


    // --- END: FULLY CORRECTED LOGIN METHOD ---

    public async Task<string?> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email.ToLower());
            if (user == null) return "Email not registered.";
            var token = Guid.NewGuid().ToString();
            user.ResetToken = token;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);
            await _userRepository.SaveChangesAsync();
            await _emailService.SendEmailAsync(dto.Email, "Reset Password", $"Your token is: {token}");
            return "Token sent to your email.";
        }

        public async Task<string?> ResetPasswordAsync(string token, ResetPasswordDto dto)
        {
            var user = await _userRepository.GetUserByResetTokenAsync(token);
            if (user == null) return "Invalid or expired token.";
            if (dto.NewPassword != dto.ConfirmPassword) return "Passwords do not match.";
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.ResetToken = null;
            user.ResetTokenExpiry = null;
            await _userRepository.SaveChangesAsync();
            return "Password changed successfully.";
        }
    }
}