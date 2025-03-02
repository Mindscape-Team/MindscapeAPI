using System.Text.Json.Serialization;

namespace MindscapeAPI.DTOs.UserProfile
{
	public class UpdateUserProfileDTO
	{
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

    }
}
