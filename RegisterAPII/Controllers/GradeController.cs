using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterAPII.Interfaces;

namespace RegisterAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _repo;
        public GradeController(IGradeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("students-by-selection")]
        public async Task<IActionResult> GetStudents([FromQuery] string grade, [FromQuery] string className, [FromQuery] int session)
        {
            var students = await _repo.GetStudentsByGradeClassSessionAsync(grade, className, session);

            return Ok(students);
        }
    }
}
