namespace MetroGuide.Models
{
    public class TourStopAttraction
    {
        public int TourStopId { get; set; }

        public TourStop TourStop { get; set; } = null!;

        public int AttractionId { get; set; }

        public Attraction Attraction { get; set; } = null!;
    }
}