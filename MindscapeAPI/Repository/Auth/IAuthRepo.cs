using MindscapeAPI.DTOs.Auth;

namespace MindscapeAPI.Repository.Auth
{
    public interface IAuthRepo
    {
        Task<AuthDTO> RegisterAsync(RegisterDTO dto);
        Task<AuthDTO> LoginAsync(LoginDTO dto);
    }
}
