namespace Game__Tournament_API.Dtos
{
    public class TournamentResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date {  get; set; }


    }
}
