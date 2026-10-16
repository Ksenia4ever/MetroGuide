namespace MetroGuide.Models
{
    public class Attraction
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? TextGuide { get; set; }

        public ICollection<StationAttraction> StationAttractions { get; set; } = new List<StationAttraction>();

        public ICollection<TourStopAttraction> TourStopAttractions { get; set; } = new List<TourStopAttraction>();

        public ICollection<AttractionMedia> Media { get; set; } = new List<AttractionMedia>();
    }
}