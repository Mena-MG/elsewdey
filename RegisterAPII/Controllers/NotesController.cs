using Microsoft.AspNetCore.Mvc;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using System.Security.Claims;

namespace RegisterAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteDto noteDto)
        {
            try
            {
                // In a real application, you would get the user ID from JWT token
                // For now, using a placeholder
                var createdByAccountId = GetCurrentUserId();
                
                var result = await _noteService.CreateNoteAsync(noteDto, createdByAccountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] UpdateNoteDto updateNoteDto)
        {
            try
            {
                var updatedByAccountId = GetCurrentUserId();
                var result = await _noteService.UpdateNoteAsync(id, updateNoteDto, updatedByAccountId);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                var deletedByAccountId = GetCurrentUserId();
                var result = await _noteService.DeleteNoteAsync(id, deletedByAccountId);
                
                if (!result)
                    return NotFound(new { message = "Note not found" });
                
                return Ok(new { message = "Note deleted successfully" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);
            if (note == null)
                return NotFound();

            return Ok(note);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetNotesByStudent(int studentId)
        {
            var notes = await _noteService.GetNotesByStudentIdAsync(studentId);
            return Ok(notes);
        }

        [HttpGet("student/{studentId}/type/{type}")]
        public async Task<IActionResult> GetNotesByType(int studentId, string type)
        {
            var notes = await _noteService.GetNotesByTypeAsync(studentId, type);
            return Ok(notes);
        }

        [HttpGet("my-notes")]
        public async Task<IActionResult> GetMyNotes()
        {
            var createdByAccountId = GetCurrentUserId();
            var notes = await _noteService.GetNotesByCreatorAsync(createdByAccountId);
            return Ok(notes);
        }

        private int GetCurrentUserId()
        {
            // In a real application, extract from JWT token
            // For now, return a placeholder (you should implement proper JWT authentication)
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            
            // Placeholder - in production, this should throw an exception or handle authentication properly
            return 1; // Default to first user for testing
        }
    }
}