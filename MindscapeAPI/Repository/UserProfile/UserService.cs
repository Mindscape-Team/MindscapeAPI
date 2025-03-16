using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using MindscapeAPI.DTOs.UserProfile;
using MindscapeAPI.Models;
using MindscapeAPI.Repository.UserProfile;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

public class UserService : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IMemoryCache _cache;

	public UserService(UserManager<ApplicationUser> userManager,IMemoryCache cache)
	{
		_userManager = userManager;
		_cache = cache;
	}

	public async Task<RetrieveUserProfileDTO> GetUserProfileAsync(string userId)
	{
		//if (_cache.TryGetValue(userId, out RetrieveUserProfileDTO cachedProfile))
		//{
		//	return cachedProfile;
		//}

		var user = await _userManager.FindByIdAsync(userId);
		if (user == null) return null;

		var userProfile = new RetrieveUserProfileDTO
		{
			FullName = user.FullName,
			Email = user.Email,
			PhoneNumber = user.PhoneNumber,
			ProfilePicture = user.ProfilePicture,
			Address = user.Address
        };

		//_cache.Set(userId, userProfile);
		return userProfile;
	}

	public async Task<bool> UpdateUserProfileAsync(string userId, UpdateUserProfileDTO updateUserProfileDTO)
	{
		var user = await _userManager.FindByIdAsync(userId);
		if (user == null) return false;

		if (!string.IsNullOrEmpty(updateUserProfileDTO.FullName) && updateUserProfileDTO.FullName != user.FullName)
			user.FullName = updateUserProfileDTO.FullName;

		if (!string.IsNullOrEmpty(updateUserProfileDTO.Email) && updateUserProfileDTO.Email != user.Email)
			user.Email = updateUserProfileDTO.Email;

		if (!string.IsNullOrEmpty(updateUserProfileDTO.PhoneNumber) && updateUserProfileDTO.PhoneNumber != user.PhoneNumber)
			user.PhoneNumber = updateUserProfileDTO.PhoneNumber;

        if (!string.IsNullOrEmpty(updateUserProfileDTO.Address) && updateUserProfileDTO.Address != user.Address)
            user.Address = updateUserProfileDTO.Address;

        var result = await _userManager.UpdateAsync(user);
		if (!result.Succeeded) return false;

		_cache.Remove(userId); 

		_cache.Set(userId, new RetrieveUserProfileDTO
		{
			FullName = user.FullName,
			Email = user.Email,
			PhoneNumber = user.PhoneNumber,
			Address = user.Address
		});

		return true;
	}

    public async Task<bool> UpdateUserProfilePictureAsync(string userId, UpdateUserProfilePictureDTO updateUserProfilePictureDTO)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        if (updateUserProfilePictureDTO.ProfilePicture != null && updateUserProfilePictureDTO.ProfilePicture != user.ProfilePicture)
            user.ProfilePicture = updateUserProfilePictureDTO.ProfilePicture;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) return false;

		return true;
    }

    public async Task<bool> DeleteUserAccountAsync(string userId)
	{
		var user = await _userManager.FindByIdAsync(userId);
		if (user == null) return false;

		var result = await _userManager.DeleteAsync(user);
		if (!result.Succeeded) return false;

		_cache.Remove(userId); 
		return true;
	}

	public async Task<(bool Success, string Message)> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
	{
		var user = await _userManager.FindByIdAsync(userId);
		if (user == null)
			return (false, "User not found.");

		var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

		if (!result.Succeeded)
		{
			string errors = string.Join(", ", result.Errors.Select(e => e.Description));
			return (false, "Password change failed: " + errors);
		}

		return (true, "Password changed successfully.");
	}

}
