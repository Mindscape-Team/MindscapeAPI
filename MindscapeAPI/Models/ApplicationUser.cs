using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MindscapeAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string FullName { get; set; }
    }
}
