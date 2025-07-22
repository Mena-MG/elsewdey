using RegisterAPII.DTOs;

namespace RegisterAPII.Interfaces
{
    public interface IStudentProfileRepository
    {
        Task<string> CreateAsync(StudentProfileDto dto);
        Task<StudentProfileDto?> GetByIdAsync(int id);
        Task<string> UpdateNotesAsync(int id, StudentProfileDto dto);
    }
}
