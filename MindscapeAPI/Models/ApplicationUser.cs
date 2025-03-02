using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MindscapeAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string FullName { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
