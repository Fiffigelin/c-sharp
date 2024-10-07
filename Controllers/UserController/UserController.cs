using Microsoft.AspNetCore.Mvc;
using c_sharp.Models.User;
using c_sharp.Service.UserService;

namespace c_sharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.RegisterUser(createUser);
            if (user == null)
            {
                return BadRequest("Användaren kunde inte registreras.");
            }

            return CreatedAtAction(nameof(GetUserByEmail), new { email = user.Email }, user);
        }

        // GET: api/user/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUserDto loginDto)
        {
            Console.WriteLine($"CONTROLLER: {loginDto.Email}");

            var user = await _userService.Login(loginDto);
            if (user == null)
            {
                return Unauthorized("Fel e-post eller lösenord.");
            }

            return Ok(user);
        }

        // GET: api/user/{email}
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound("Användaren hittades inte.");
            }

            return Ok(user);
        }
    }
}
