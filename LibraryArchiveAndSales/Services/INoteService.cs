using LibraryArchiveAndSales.Models.Entities;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Services
{
    public interface INoteService
    {
        Task<Note> AddNoteAsync(NoteDto noteDto);
        Task UpdateNoteAsync(int id, NoteDto noteDto);
        Task DeleteNoteAsync(int id);
        Task<IEnumerable<Note>> GetNotesByBookIdAsync(int bookId);
    }
}
