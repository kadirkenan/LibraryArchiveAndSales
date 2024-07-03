using LibraryArchiveAndSales.Models.Entities;
using LibraryArchiveAndSales.Repositories;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> AddNoteAsync(NoteDto noteDto)
        {
            var note = new Note
            {
                BookId = noteDto.BookId,
                Content = noteDto.Content,
                IsShared = noteDto.IsShared
            };
            await _noteRepository.AddAsync(note);
            return note;
        }

        public async Task UpdateNoteAsync(int id, NoteDto noteDto)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note != null)
            {
                note.Content = noteDto.Content;
                note.IsShared = noteDto.IsShared;
                _noteRepository.Update(note);
            }
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note != null)
            {
                _noteRepository.Delete(note);
            }
        }

        public async Task<IEnumerable<Note>> GetNotesByBookIdAsync(int bookId)
        {
            return await _noteRepository.FindAsync(n => n.BookId == bookId);
        }
    }
}
