using Bookify.Service.Beans;
using Bookify.Service.Beans.Response;
using Bookify.Service.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister userRegister)
        {
            if(userRegister == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _userService.SignUp(userRegister);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterResponse { Errors = errors, IsSuccessfulRegister = false });
            }

            return Ok(new RegisterResponse { IsSuccessfulRegister = true });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if (userLogin == null || !ModelState.IsValid)
                return BadRequest();

            var token = await _userService.SignIn(userLogin);

            if (token == null)
                return Unauthorized(new AuthResponse { IsAuthSuccess = false, ErrorMessage = "Invalid Authentication User" });

            return Ok(new AuthResponse { IsAuthSuccess = true, Token = token });
        }

        [HttpGet("UserStatus")]
        public IActionResult GetUserStatus()
        {
            var useremail = User.Claims.FirstOrDefault();
            if (useremail == null)
                return Unauthorized(new GeneralResponse { Status = false, Errors = new List<string> { "User Session Timeout" } });

            return Ok(new GeneralResponse { Status = true });
        }
    }
}
