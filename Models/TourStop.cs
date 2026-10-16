namespace MetroGuide.Models
{
    public class TourStop
    {
        public int Id { get; set; }

        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int MetroStationId { get; set; }

        public MetroStation MetroStation { get; set; } = null!;

        public int StopOrder { get; set; }

        public string? GuideComment { get; set; }

        public ICollection<TourStopAttraction> TourStopAttractions { get; set; } = new List<TourStopAttraction>();
    }
}