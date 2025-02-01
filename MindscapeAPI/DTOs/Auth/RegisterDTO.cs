using System.ComponentModel.DataAnnotations;

namespace MindscapeAPI.DTOs.Auth
{
    public class RegisterDTO
    {
        [MaxLength(250)]
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
