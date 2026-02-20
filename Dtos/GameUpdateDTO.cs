using System.ComponentModel.DataAnnotations;

namespace Game__Tournament_API.Dtos;

public class GameUpdateDTO
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public DateTime Time { get; set; }
}