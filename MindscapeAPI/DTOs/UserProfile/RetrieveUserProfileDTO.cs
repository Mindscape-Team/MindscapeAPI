﻿namespace MindscapeAPI.DTOs.UserProfile
{
	public class RetrieveUserProfileDTO
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
        public string ProfilePicture { get; set; }
    }
}
