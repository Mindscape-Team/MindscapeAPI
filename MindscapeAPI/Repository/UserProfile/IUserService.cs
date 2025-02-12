using MindscapeAPI.DTOs.UserProfile;

namespace MindscapeAPI.Repository.UserProfile
{
	public interface IUserService
	{
		Task<RetrieveUserProfileDTO> GetUserProfileAsync(string userId);
		Task<bool> UpdateUserProfileAsync(string userId, UpdateUserProfileDTO updateUserProfileDTO);
	}
}
