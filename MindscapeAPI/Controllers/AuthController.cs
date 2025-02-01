using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindscapeAPI.DTOs.Auth;
using MindscapeAPI.Repository.Auth;

namespace MindscapeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepo.RegisterAsync(dto);

            if (!result.isValid)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepo.LoginAsync(dto);

            if (!result.isValid)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
