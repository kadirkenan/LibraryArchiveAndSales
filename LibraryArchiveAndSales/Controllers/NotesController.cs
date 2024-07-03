using LibraryArchiveAndSales.Models.Dtos;
using LibraryArchiveAndSales.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryArchiveAndSales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteDto noteDto)
        {
            var note = await _noteService.AddNoteAsync(noteDto);
            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, NoteDto noteDto)
        {
            await _noteService.UpdateNoteAsync(id, noteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            await _noteService.DeleteNoteAsync(id);
            return NoContent();
        }

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetNotesByBookId(int bookId)
        {
            var notes = await _noteService.GetNotesByBookIdAsync(bookId);
            return Ok(notes);
        }
    }
}
