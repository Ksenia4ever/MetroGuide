namespace MetroGuide.Domain.Entities
{
    public class MetroStation
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int MetroLineId { get; set; }

        public MetroLine MetroLine { get; set; } = null!;

        public double MapX { get; set; }

        public double MapY { get; set; }

        public ICollection<StationAttraction> StationAttractions { get; set; }
            = new List<StationAttraction>();

        public ICollection<TourStop> TourStops { get; set; } = new List<TourStop>();
    }
}