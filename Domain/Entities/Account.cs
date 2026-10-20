namespace MetroGuide.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string IdentityUserId { get; set; } = string.Empty;

        public ICollection<UserTour> UserTours { get; set; } = new List<UserTour>();

        public ICollection<FavoriteTour> FavoriteTours { get; set; } = new List<FavoriteTour>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}



