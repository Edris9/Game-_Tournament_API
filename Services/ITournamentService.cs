using Game__Tournament_API.Dtos;

namespace Game__Tournament_API.Services;

public interface ITournamentService
{
    Task<IEnumerable<TournamentResponseDTO>> GetAllAsync(string? search);
    Task<TournamentResponseDTO?> GetByIdAsync(int id);
    Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto);
    Task<TournamentResponseDTO?> UpdateAsync(int id, TournamentUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}

