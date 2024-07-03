using LibraryArchiveAndSales.Models.Context;
using LibraryArchiveAndSales.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryArchiveAndSales.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            return await _dbSet
                .Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
