using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;
using System.Text.Json;

namespace RegisterAPII.Repos
{
    public class StudentProfileRepository : IStudentProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAsync(StudentProfileDto dto)
        {
            var student = new StudentProfile
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Age = dto.Age,
                City = dto.City,
                Country = dto.Country,
                DaysAbsent = dto.DaysAbsent,
                GoodNotesJson = JsonSerializer.Serialize(dto.GoodNotes),
                BadNotesJson = JsonSerializer.Serialize(dto.BadNotes),
                CreatedAt = DateTime.UtcNow,
                ClassId = dto.ClassId
            };
            _context.StudentProfiles.Add(student);
            try
            {
                await _context.SaveChangesAsync();
                return "Profile created successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Save Failed: " + ex.InnerException?.Message ?? ex.Message);
            }
        }
        public async Task<StudentProfileDto?> GetByIdAsync(int id)
        {
            var student = await _context.StudentProfiles.FindAsync(id);
            if (student == null) return null;

            return new StudentProfileDto
            {
                Name = student.Name,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Age = student.Age,
                City = student.City,
                Country = student.Country,
                DaysAbsent = student.DaysAbsent,
                GoodNotes = JsonSerializer.Deserialize<List<string>>(student.GoodNotesJson ?? "[]"),
                BadNotes = JsonSerializer.Deserialize<List<string>>(student.BadNotesJson ?? "[]"),
                CreatedAt = student.CreatedAt,
                ClassId = student.ClassId
            };
        }
        public async Task<string> UpdateNotesAsync(int id, StudentProfileDto dto)
        {
            var student = await _context.StudentProfiles.FindAsync(id);
            if (student == null) return "Student not found";

            student.GoodNotesJson = JsonSerializer.Serialize(dto.GoodNotes);
            student.BadNotesJson = JsonSerializer.Serialize(dto.BadNotes);

            await _context.SaveChangesAsync();
            return "Notes updated";
        }
    }
}
