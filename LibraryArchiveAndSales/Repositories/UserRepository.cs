using LibraryArchiveAndSales.Models.Context;
using LibraryArchiveAndSales.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryArchiveAndSales.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LibraryContext context) : base(context) { }

        public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
