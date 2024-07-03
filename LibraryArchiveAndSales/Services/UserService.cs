using LibraryArchiveAndSales.Models.Dtos;
using LibraryArchiveAndSales.Models.Entities;
using LibraryArchiveAndSales.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryArchiveAndSales.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAndPasswordAsync(username, password);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:DurationInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDto> RegisterAsync(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Email = userDto.Email
            };

            await _userRepository.AddAsync(user);
            return userDto;
        }

        public async Task UpdateUserAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                user.Username = userDto.Username;
                user.Password = userDto.Password;
                user.Email = userDto.Email;
                _userRepository.Update(user);
            }
        }
    }
}
