using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MindscapeAPI.Data;
using MindscapeAPI.DTOs.UserProfile;

namespace MindscapeAPI.Repository.UserProfile
{
	public class UserService:IUserService
	{
		private readonly ApplicationDbContext _context;
		private readonly IMemoryCache _cache;

        public UserService(ApplicationDbContext context, IMemoryCache cache)
        {
			_context = context;
            _cache = cache;
        }

		public async Task<RetrieveUserProfileDTO> GetUserProfileAsync(string userId)
		{
			if (_cache.TryGetValue(userId, out RetrieveUserProfileDTO cachedProfile))
			{
				return cachedProfile;
			}

			var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id == userId);
			if (user == null) return null;

			var userProfile = new RetrieveUserProfileDTO
			{
				FullName = user.FullName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber
			};
			_cache.Set(userId, userProfile);

			return userProfile;
		}

		public async Task<bool> UpdateUserProfileAsync(string userId, UpdateUserProfileDTO updateUserProfileDTO)
		{

			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
			if (user == null) return false;

			if(updateUserProfileDTO.FullName != user.FullName) 
			      user.FullName = updateUserProfileDTO.FullName;

			if (updateUserProfileDTO.Email != user.Email)
				user.Email = updateUserProfileDTO.Email;            

            if (updateUserProfileDTO.PhoneNumber != user.PhoneNumber)
				user.PhoneNumber = updateUserProfileDTO.PhoneNumber;

			await _context.SaveChangesAsync();
			_cache.Remove(userId);

			var updateUserProfile = new UpdateUserProfileDTO
			{
				FullName = user.FullName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber
			};
			_cache.Set(userId, updateUserProfile);

			return true;
		}
	}
}
