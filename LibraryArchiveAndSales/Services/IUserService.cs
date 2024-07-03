using LibraryArchiveAndSales.Models.Dtos;
using LibraryArchiveAndSales.Models.Entities;

namespace LibraryArchiveAndSales.Services
{
    public interface IUserService
    {
        Task<string> LoginAsync(string username, string password);
        Task<UserDto> RegisterAsync(UserDto userDto);
        Task UpdateUserAsync(int id, UserDto userDto);
    }
}
