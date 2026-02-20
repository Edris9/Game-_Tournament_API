using Game__Tournament_API.Data;
using Game__Tournament_API.Dtos;
using Game__Tournament_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Game__Tournament_API.Services;

public class GameService : IGameService
{
    private readonly AppDbContext _context;

    public GameService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameResponseDTO>> GetAllAsync()
    {
        return await _context.Games.Select(g => new GameResponseDTO
        {
            Id = g.Id,
            Title = g.Title,
            Time = g.Time,
            TournamentId = g.TournamentId
        }).ToListAsync();
    }

    public async Task<GameResponseDTO?> GetByIdAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);

        if (game == null) return null;

        return new GameResponseDTO
        {
            Id = game.Id,
            Title = game.Title,
            Time = game.Time,
            TournamentId = game.TournamentId
        };
    }

    public async Task<GameResponseDTO?> CreateAsync(GameCreateDTO dto)
    {
        // Kolla att Tournament finns
        var tournament = await _context.Tournaments.FindAsync(dto.TournamentId);
        if (tournament == null) return null;

        var game = new Game
        {
            Title = dto.Title,
            Time = dto.Time,
            TournamentId = dto.TournamentId
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return new GameResponseDTO
        {
            Id = game.Id,
            Title = game.Title,
            Time = game.Time,
            TournamentId = game.TournamentId
        };
    }

    public async Task<GameResponseDTO?> UpdateAsync(int id, GameUpdateDTO dto)
    {
        var game = await _context.Games.FindAsync(id);

        if (game == null) return null;

        game.Title = dto.Title;
        game.Time = dto.Time;

        await _context.SaveChangesAsync();

        return new GameResponseDTO
        {
            Id = game.Id,
            Title = game.Title,
            Time = game.Time,
            TournamentId = game.TournamentId
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);

        if (game == null) return false;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return true;
    }
}