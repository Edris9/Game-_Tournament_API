using System.ComponentModel.DataAnnotations;
namespace Game__Tournament_API.Dtos
{
    public class TournamentUpdateDTO
    {
        [Required]
        [MinLength(5)]

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int MaxPlayers { get; set; }

        [FutureDate]
        public DateTime Date { get; set; }
    }


}
