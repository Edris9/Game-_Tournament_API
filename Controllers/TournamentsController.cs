using Game__Tournament_API.Dtos;
using Game__Tournament_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;

namespace Game__Tournament_API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;

    public TournamentsController(ITournamentService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<TournamentResponseDTO>>> GetAll([FromQuery] string? search)
    {
        var tournaments = await _service.GetAllAsync(search);
        return Ok(tournaments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TournamentResponseDTO>> GetById(int id)
    {
        var tournament = await _service.GetByIdAsync(id);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [EnableRateLimiting("fixed")]
    [HttpPost]
    public async Task<ActionResult<TournamentResponseDTO>> Create(TournamentCreateDTO dto)
    {
        var tournament = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = tournament.Id }, tournament);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TournamentResponseDTO>> Update(int id, TournamentUpdateDTO dto)
    {
        var tournament = await _service.UpdateAsync(id, dto);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }


}