using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;

namespace RegisterAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly IStudentProfileRepository _repository;
        public StudentProfileController(IStudentProfileRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateStudentProfile([FromBody] StudentProfileDto dto)
        {
            var result = await _repository.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var profile = await _repository.GetByIdAsync(id);
            if (profile == null) return NotFound();

            return Ok(profile);
        }

        [HttpPut("{id}/update-notes")]
        public async Task<IActionResult> UpdateNotes(int id, [FromBody] StudentProfileDto dto)
        {
            var result = await _repository.UpdateNotesAsync(id, dto);
            if (result == "Student not found") return NotFound();

            return Ok(result);
        }
    }
}
