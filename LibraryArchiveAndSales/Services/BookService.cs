using LibraryArchiveAndSales.Models.Entities;
using LibraryArchiveAndSales.Repositories;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                ShelfLocation = bookDto.ShelfLocation,
                CoverImageUrl = bookDto.CoverImageUrl
            };
            await _bookRepository.AddAsync(book);
            return book;
        }

        public async Task UpdateBookAsync(int id, BookDto bookDto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                book.Title = bookDto.Title;
                book.Author = bookDto.Author;
                book.ISBN = bookDto.ISBN;
                book.ShelfLocation = bookDto.ShelfLocation;
                book.CoverImageUrl = bookDto.CoverImageUrl;
                _bookRepository.Update(book);
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            return await _bookRepository.SearchBooksAsync(searchTerm);
        }
    }
}
