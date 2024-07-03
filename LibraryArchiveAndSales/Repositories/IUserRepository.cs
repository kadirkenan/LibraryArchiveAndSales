using LibraryArchiveAndSales.Models.Entities;

namespace LibraryArchiveAndSales.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
