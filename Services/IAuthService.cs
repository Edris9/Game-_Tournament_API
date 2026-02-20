using Game__Tournament_API.Dtos;

namespace Game__Tournament_API.Services;

public interface IAuthService
{
    Task<AuthResponseDTO?> RegisterAsync(RegisterDTO dto);
    Task<AuthResponseDTO?> LoginAsync(LoginDTO dto);
}