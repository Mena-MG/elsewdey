using RegisterAPII.DTOs;

namespace RegisterAPII.Interfaces
{
    public interface INoteService
    {
        Task<NoteResponseDto> CreateNoteAsync(NoteDto noteDto, int createdByAccountId);
        Task<NoteResponseDto> UpdateNoteAsync(int noteId, UpdateNoteDto updateNoteDto, int updatedByAccountId);
        Task<bool> DeleteNoteAsync(int noteId, int deletedByAccountId);
        Task<NoteResponseDto?> GetNoteByIdAsync(int noteId);
        Task<List<NoteResponseDto>> GetNotesByStudentIdAsync(int studentId);
        Task<List<NoteResponseDto>> GetNotesByTypeAsync(int studentId, string type);
        Task<List<NoteResponseDto>> GetNotesByCreatorAsync(int createdByAccountId);
    }
}