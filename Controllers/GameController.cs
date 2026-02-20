using Game__Tournament_API.Dtos;
using Game__Tournament_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game__Tournament_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;

    public GamesController(IGameService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetAll()
    {
        var games = await _service.GetAllAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameResponseDTO>> GetById(int id)
    {
        var game = await _service.GetByIdAsync(id);
        if (game == null) return NotFound();
        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<GameResponseDTO>> Create(GameCreateDTO dto)
    {
        var game = await _service.CreateAsync(dto);
        if (game == null) return BadRequest("Tournament not found");
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameResponseDTO>> Update(int id, GameUpdateDTO dto)
    {
        var game = await _service.UpdateAsync(id, dto);
        if (game == null) return NotFound();
        return Ok(game);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}