// --- File: Interfaces/IJwtService.cs ---

using RegisterAPII.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RegisterAPII.Interfaces
{
    public interface IJwtService
    {
        // FIX: The method now accepts a list of claims directly instead of a User object.
        string GenerateToken(Accounts user);
    }
}