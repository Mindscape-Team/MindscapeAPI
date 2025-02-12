using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindscapeAPI.DTOs.UserProfile;
using MindscapeAPI.Repository.UserProfile;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MindscapeAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

		[HttpGet("RetrieveProfile")]
		public async Task<IActionResult> GetUserProfile()
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var profile = await _userService.GetUserProfileAsync(user);
			if (profile == null) return NotFound("User not found");

			return Ok(profile);
		}

		[HttpPut("UpdateProfile")]
		public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDTO updateUserProfileDTO)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (userId == null) return Unauthorized();

			var success = await _userService.UpdateUserProfileAsync(userId, updateUserProfileDTO);
			if (!success) return NotFound();

			return Ok("Profile updated successfully");
		}

		[HttpDelete("DeleteAccount")]
		public async Task<IActionResult> DeleteAccount()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (userId == null) return Unauthorized();

			var result = await _userService.DeleteUserAccountAsync(userId);
			if (!result)
				return BadRequest("Failed to delete account.");

			return NoContent();
		}

		[HttpPost("ChangePassword")]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (userId == null) return Unauthorized();

			var result = await _userService.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);
			if(!result.Success) return BadRequest(result.Message);

			return Ok(result.Message);
		}
	}
}
