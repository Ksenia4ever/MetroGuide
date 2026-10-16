namespace MetroGuide.Models
{
    public class Tour
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int DurationMinutes { get; set; }

        public ICollection<TourStop> TourStops { get; set; }
            = new List<TourStop>();

        public ICollection<TourThemeLink> TourThemeLinks { get; set; }
            = new List<TourThemeLink>();
    }
}