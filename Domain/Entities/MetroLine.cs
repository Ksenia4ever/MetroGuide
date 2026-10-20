namespace MetroGuide.Domain.Entities
{
    public class MetroLine
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public ICollection<MetroStation> Stations { get; set; }
            = new List<MetroStation>();
    }
}