using Game__Tournament_API.Dtos;

namespace Game__Tournament_API.Services;

public interface IGameService
{
    Task<IEnumerable<GameResponseDTO>> GetAllAsync();
    Task<GameResponseDTO?> GetByIdAsync(int id);
    Task<GameResponseDTO?> CreateAsync(GameCreateDTO dto);
    Task<GameResponseDTO?> UpdateAsync(int id, GameUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}