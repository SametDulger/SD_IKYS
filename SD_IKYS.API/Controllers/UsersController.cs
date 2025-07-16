using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;

namespace SD_IKYS.API.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(CreateUserDto createUserDto)
        {
            try
            {
                var user = await _userService.CreateAsync(createUserDto);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _userService.UpdateAsync(id, updateUserDto);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userService.AuthenticateAsync(loginDto);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

        [HttpGet("check-username/{username}")]
        public async Task<ActionResult<bool>> CheckUsername(string username)
        {
            var exists = await _userService.UsernameExistsAsync(username);
            return Ok(exists);
        }

        [HttpGet("check-email/{email}")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var exists = await _userService.EmailExistsAsync(email);
            return Ok(exists);
        }
    }
} 