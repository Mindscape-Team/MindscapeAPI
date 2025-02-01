namespace MindscapeAPI.DTOs.Auth
{
    public class AuthDTO
    {
        public string Message { get; set; }
        public bool isValid { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
