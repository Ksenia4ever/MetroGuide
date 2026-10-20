namespace MetroGuide.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!;

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}