using Microsoft.EntityFrameworkCore;
using RegisterAPII.DATA;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;

namespace RegisterAPII.Repos
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NoteResponseDto> CreateNoteAsync(NoteDto noteDto, int createdByAccountId)
        {
            var note = new Note
            {
                Content = noteDto.Content,
                Type = noteDto.Type,
                StudentProfileId = noteDto.StudentProfileId,
                CreatedByAccountId = createdByAccountId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            // TODO: Send notification (implement notification sending separately to avoid circular dependency)
            // await _notificationService.SendNoteNotificationAsync(note.Id, createdByAccountId);

            return await GetNoteByIdAsync(note.Id);
        }

        public async Task<NoteResponseDto> UpdateNoteAsync(int noteId, UpdateNoteDto updateNoteDto, int updatedByAccountId)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if (note == null)
                throw new ArgumentException("Note not found");

            // Only allow the creator to update their own notes
            if (note.CreatedByAccountId != updatedByAccountId)
                throw new UnauthorizedAccessException("You can only update your own notes");

            note.Content = updateNoteDto.Content;
            note.Type = updateNoteDto.Type;
            note.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetNoteByIdAsync(noteId);
        }

        public async Task<bool> DeleteNoteAsync(int noteId, int deletedByAccountId)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if (note == null)
                return false;

            // Only allow the creator to delete their own notes
            if (note.CreatedByAccountId != deletedByAccountId)
                throw new UnauthorizedAccessException("You can only delete your own notes");

            note.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<NoteResponseDto?> GetNoteByIdAsync(int noteId)
        {
            var note = await _context.Notes
                .Include(n => n.StudentProfile)
                .Include(n => n.CreatedBy)
                .FirstOrDefaultAsync(n => n.Id == noteId && n.IsActive);

            if (note == null)
                return null;

            return new NoteResponseDto
            {
                Id = note.Id,
                Content = note.Content,
                Type = note.Type,
                StudentProfileId = note.StudentProfileId,
                StudentName = note.StudentProfile.Name ?? "",
                CreatedByAccountId = note.CreatedByAccountId,
                CreatedByName = note.CreatedBy.FullName,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                IsActive = note.IsActive
            };
        }

        public async Task<List<NoteResponseDto>> GetNotesByStudentIdAsync(int studentId)
        {
            var notes = await _context.Notes
                .Include(n => n.StudentProfile)
                .Include(n => n.CreatedBy)
                .Where(n => n.StudentProfileId == studentId && n.IsActive)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes.Select(note => new NoteResponseDto
            {
                Id = note.Id,
                Content = note.Content,
                Type = note.Type,
                StudentProfileId = note.StudentProfileId,
                StudentName = note.StudentProfile.Name ?? "",
                CreatedByAccountId = note.CreatedByAccountId,
                CreatedByName = note.CreatedBy.FullName,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                IsActive = note.IsActive
            }).ToList();
        }

        public async Task<List<NoteResponseDto>> GetNotesByTypeAsync(int studentId, string type)
        {
            var notes = await _context.Notes
                .Include(n => n.StudentProfile)
                .Include(n => n.CreatedBy)
                .Where(n => n.StudentProfileId == studentId && n.Type == type && n.IsActive)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes.Select(note => new NoteResponseDto
            {
                Id = note.Id,
                Content = note.Content,
                Type = note.Type,
                StudentProfileId = note.StudentProfileId,
                StudentName = note.StudentProfile.Name ?? "",
                CreatedByAccountId = note.CreatedByAccountId,
                CreatedByName = note.CreatedBy.FullName,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                IsActive = note.IsActive
            }).ToList();
        }

        public async Task<List<NoteResponseDto>> GetNotesByCreatorAsync(int createdByAccountId)
        {
            var notes = await _context.Notes
                .Include(n => n.StudentProfile)
                .Include(n => n.CreatedBy)
                .Where(n => n.CreatedByAccountId == createdByAccountId && n.IsActive)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes.Select(note => new NoteResponseDto
            {
                Id = note.Id,
                Content = note.Content,
                Type = note.Type,
                StudentProfileId = note.StudentProfileId,
                StudentName = note.StudentProfile.Name ?? "",
                CreatedByAccountId = note.CreatedByAccountId,
                CreatedByName = note.CreatedBy.FullName,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                IsActive = note.IsActive
            }).ToList();
        }
    }
}