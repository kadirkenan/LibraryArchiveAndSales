using LibraryArchiveAndSales.Models.Entities;

namespace LibraryArchiveAndSales.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm);
    }
}
