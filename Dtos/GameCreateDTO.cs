using System.ComponentModel.DataAnnotations;

namespace Game__Tournament_API.Dtos;

public class GameCreateDTO
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    [FutureDate]
    public DateTime Time { get; set; }

    [Required]
    public int TournamentId { get; set; }
}