using RegisterAPII.DTOs;

namespace RegisterAPII.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<StudentProfileDto>> GetStudentsByGradeClassSessionAsync(string gradeName, string className, int sessionName);
    }
}
