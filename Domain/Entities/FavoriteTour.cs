namespace MetroGuide.Domain.Entities
{
    public class FavoriteTour
    {
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!;
    }
}