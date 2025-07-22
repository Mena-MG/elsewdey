using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;

namespace RegisterAPII.Repos
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentProfileDto>> GetStudentsByGradeClassSessionAsync(string gradeName, string className, int sessionName)
        {
            var classEntity = await _context.ClassRooms
                .Include(c => c.Grade)
                .Include(c => c.Students)
                .Include(c => c.Sessions)
                .FirstOrDefaultAsync(c =>
                    c.Name == className &&
                    c.Grade.Name == gradeName &&
                    c.Sessions.Any(s => s.sessionNo == sessionName));

            if (classEntity == null)
                return new List<StudentProfileDto>();

            return classEntity.Students.Select(s => new StudentProfileDto
            {
                Name = s.Name,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Age = s.Age,
                DaysAbsent = s.DaysAbsent
            }).ToList();
        }
    }
}
