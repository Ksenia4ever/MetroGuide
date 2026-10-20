namespace MetroGuide.Domain.Entities
{
    public class AttractionMedia
    {
        public int Id { get; set; }

        public int AttractionId { get; set; }

        public Attraction Attraction { get; set; } = null!;

        public string Url { get; set; } = string.Empty;

        public string MediaType { get; set; } = string.Empty;
    }
}