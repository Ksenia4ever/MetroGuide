namespace MetroGuide.Domain.Entities
{
    public class UserTour
    {
        public int Id { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!;

        public DateTime StartedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public int? CurrentTourStopId { get; set; }
        public TourStop? CurrentTourStop { get; set; }

        public string Status { get; set; } = "Started";
    }
}