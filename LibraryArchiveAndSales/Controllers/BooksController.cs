using LibraryArchiveAndSales.Models;
using LibraryArchiveAndSales.Models.Dtos;
using LibraryArchiveAndSales.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryArchiveAndSales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            var book = await _bookService.AddBookAsync(bookDto);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            await _bookService.UpdateBookAsync(id, bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks(string searchTerm)
        {
            var books = await _bookService.SearchBooksAsync(searchTerm);
            return Ok(books);
        }
    }
}
