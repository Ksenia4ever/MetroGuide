namespace MetroGuide.Models
{
    public class TourThemeLink
    {
        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int TourThemeId { get; set; }

        public TourTheme TourTheme { get; set; } = null!;
    }
}