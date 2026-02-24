using Game__Tournament_API.Dtos;
using Game__Tournament_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Logging;

namespace Game__Tournament_API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;
    private readonly ILogger<TournamentsController> _logger;
    public TournamentsController(ITournamentService service, ILogger<TournamentsController> logger)
    {
        _service = service;
        _logger = logger;
    }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<TournamentResponseDTO>>> GetAll([FromQuery] string? search)
    {
        _logger.LogInformation("Getting all tournaments with search: {Search}", search);
        var tournaments = await _service.GetAllAsync(search);
        return Ok(tournaments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TournamentResponseDTO>> GetById(int id)
    {
        _logger.LogInformation("Getting tournament by id: {Id}", id);
        var tournament = await _service.GetByIdAsync(id);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [EnableRateLimiting("fixed")]
    [HttpPost]
    public async Task<ActionResult<TournamentResponseDTO>> Create(TournamentCreateDTO dto)
    {
        _logger.LogInformation("Creating tournament with title: {Title}", dto.Title);
        var tournament = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = tournament.Id }, tournament);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TournamentResponseDTO>> Update(int id, TournamentUpdateDTO dto)
    {
        _logger.LogInformation("Updating tournament with id: {Id}", id);
        var tournament = await _service.UpdateAsync(id, dto);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        _logger.LogInformation("Deleting tournament with id: {Id}", id);
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }


}