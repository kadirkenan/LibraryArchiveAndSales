using LibraryArchiveAndSales.Models.Context;
using LibraryArchiveAndSales.Models.Entities;

namespace LibraryArchiveAndSales.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(LibraryContext context) : base(context) { }
    }
}
