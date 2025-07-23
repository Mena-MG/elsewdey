using RegisterAPII.DTOs;

namespace RegisterAPII.Interfaces
{
    public interface IStaffManagementService
    {
        Task<StaffResponseDto> CreateStaffAsync(CreateStaffDto createStaffDto);
        Task<StaffResponseDto> UpdateStaffAsync(int staffId, UpdateStaffDto updateStaffDto);
        Task<bool> DeleteStaffAsync(int staffId);
        Task<StaffResponseDto?> GetStaffByIdAsync(int staffId);
        Task<List<StaffResponseDto>> GetAllStaffAsync();
        Task<List<StaffResponseDto>> GetStaffByRoleAsync(int roleId);
        Task<bool> ActivateStaffAsync(int staffId);
        Task<bool> DeactivateStaffAsync(int staffId);
    }
}