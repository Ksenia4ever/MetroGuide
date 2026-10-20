namespace MetroGuide.Domain.Entities
{
    public class StationAttraction
    {
        public int MetroStationId { get; set; }

        public MetroStation MetroStation { get; set; } = null!;

        public int AttractionId { get; set; }

        public Attraction Attraction { get; set; } = null!;

        public int DistanceMeters { get; set; }

        public int? WalkingMinutes { get; set; }
    }
}