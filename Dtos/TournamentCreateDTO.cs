using System.ComponentModel.DataAnnotations;
namespace Game__Tournament_API.Dtos
{
    public class TournamentCreateDTO
    {
        [Required]
        [MinLength(5)]

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MaxPlayers { get; set; }

        [FutureDate]
        public DateTime Date { get; set; }

    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (value is DateTime date && date <= DateTime.Now)
            {
                return new ValidationResult("Date måste vara i framtiden!");
            }
            return ValidationResult.Success;
        }
    }
}
