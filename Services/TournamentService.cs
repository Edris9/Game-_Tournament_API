using Game__Tournament_API.Data;
using Game__Tournament_API.Dtos;
using Game__Tournament_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Game__Tournament_API.Services;

public class TournamentService : ITournamentService
{
    private readonly AppDbContext _context;

    public TournamentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TournamentResponseDTO>> GetAllAsync(string? search)
    {
        var query = _context.Tournaments.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(t => t.Title.Contains(search));
        }

        return await query.Select(t => new TournamentResponseDTO
        {
            Id = t.Id,
            Title = t.Title,
            Date = t.Date
        }).ToListAsync();
    }

    public async Task<TournamentResponseDTO?> GetByIdAsync(int id)
    {
        var tournament = await _context.Tournaments.FindAsync(id);

        if (tournament == null) return null;

        return new TournamentResponseDTO
        {
            Id = tournament.Id,
            Title = tournament.Title,
            Date = tournament.Date
        };
    }

    public async Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto)
    {
        var tournament = new Tournament
        {
            Title = dto.Title,
            Description = dto.Description,
            MaxPlayers = dto.MaxPlayers,
            Date = dto.Date
        };

        _context.Tournaments.Add(tournament);
        await _context.SaveChangesAsync();

        return new TournamentResponseDTO
        {
            Id = tournament.Id,
            Title = tournament.Title,
            Date = tournament.Date
        };
    }

    public async Task<TournamentResponseDTO?> UpdateAsync(int id, TournamentUpdateDTO dto)
    {
        var tournament = await _context.Tournaments.FindAsync(id);

        if (tournament == null) return null;

        tournament.Title = dto.Title;
        tournament.Description = dto.Description;
        tournament.MaxPlayers = dto.MaxPlayers;
        tournament.Date = dto.Date;

        await _context.SaveChangesAsync();

        return new TournamentResponseDTO
        {
            Id = tournament.Id,
            Title = tournament.Title,
            Date = tournament.Date
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tournament = await _context.Tournaments.FindAsync(id);

        if (tournament == null) return false;

        _context.Tournaments.Remove(tournament);
        await _context.SaveChangesAsync();

        return true;
    }
}