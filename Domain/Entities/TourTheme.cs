namespace MetroGuide.Domain.Entities
{
    public class TourTheme
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<TourThemeLink> TourThemeLinks { get; set; }
            = new List<TourThemeLink>();
    }
}