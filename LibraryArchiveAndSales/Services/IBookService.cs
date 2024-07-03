using LibraryArchiveAndSales.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Services
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(BookDto bookDto);
        Task UpdateBookAsync(int id, BookDto bookDto);
        Task DeleteBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm);
    }
}
