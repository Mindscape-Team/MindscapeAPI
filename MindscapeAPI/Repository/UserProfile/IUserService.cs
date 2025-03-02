using MindscapeAPI.DTOs.UserProfile;

namespace MindscapeAPI.Repository.UserProfile
{
	public interface IUserService
	{
		Task<RetrieveUserProfileDTO> GetUserProfileAsync(string userId);
		Task<bool> UpdateUserProfileAsync(string userId, UpdateUserProfileDTO updateUserProfileDTO);
		Task<bool> UpdateUserProfilePictureAsync(string userId, UpdateUserProfilePictureDTO updateUserProfilePictureDTO);
		Task<bool> DeleteUserAccountAsync(string userId);
		Task<(bool Success, string Message)> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
	}
}
