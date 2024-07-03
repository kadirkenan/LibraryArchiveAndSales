using LibraryArchiveAndSales.Models.Dtos;
using LibraryArchiveAndSales.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryArchiveAndSales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var user = await _userService.RegisterAsync(userDto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto.Username, loginDto.Password);
            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(new { token });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            return NoContent();
        }
    }
}
