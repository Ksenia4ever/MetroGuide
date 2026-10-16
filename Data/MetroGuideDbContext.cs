using MetroGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MetroGuide.Data
{
    public class MetroGuideDbContext : IdentityDbContext<ApplicationUser>
    {
        public MetroGuideDbContext(DbContextOptions<MetroGuideDbContext> options)
            : base(options)
        {
        }

        public DbSet<MetroLine> MetroLines { get; set; }
        public DbSet<MetroStation> MetroStations { get; set; }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<StationAttraction> StationAttractions { get; set; }
        public DbSet<AttractionMedia> AttractionMedia { get; set; }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourStop> TourStops { get; set; }

        public DbSet<TourTheme> TourThemes { get; set; }
        public DbSet<TourThemeLink> TourThemeLinks { get; set; }

        public DbSet<TourStopAttraction> TourStopAttractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================================================
            // MetroLine
            // =========================================================

            modelBuilder.Entity<MetroLine>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.Color)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasIndex(x => x.Name)
                    .IsUnique();
            });

            // =========================================================
            // MetroStation
            // =========================================================

            modelBuilder.Entity<MetroStation>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(x => x.MetroLine)
                    .WithMany(x => x.Stations)
                    .HasForeignKey(x => x.MetroLineId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================
            // Attraction
            // =========================================================

            modelBuilder.Entity<Attraction>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.Description)
                    .IsRequired();

                entity.Property(x => x.TextGuide);
            });

            // =========================================================
            // StationAttraction
            // MetroStation M:N Attraction
            // =========================================================

            modelBuilder.Entity<StationAttraction>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.MetroStationId,
                    x.AttractionId
                });

                entity.HasOne(x => x.MetroStation)
                    .WithMany(x => x.StationAttractions)
                    .HasForeignKey(x => x.MetroStationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Attraction)
                    .WithMany(x => x.StationAttractions)
                    .HasForeignKey(x => x.AttractionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================================================
            // AttractionMedia
            // =========================================================

            modelBuilder.Entity<AttractionMedia>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Url)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(x => x.MediaType)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(x => x.Attraction)
                    .WithMany(x => x.Media)
                    .HasForeignKey(x => x.AttractionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================================================
            // Tour
            // =========================================================

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.Description)
                    .IsRequired();
            });

            // =========================================================
            // TourStop
            // =========================================================

            modelBuilder.Entity<TourStop>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.GuideComment);

                // В одной экскурсии не может быть
                // двух остановок с одинаковым номером.
                entity.HasIndex(x => new
                {
                    x.TourId,
                    x.StopOrder
                })
                .IsUnique();

                // Если удаляем экскурсию,
                // её остановки тоже удаляются.
                entity.HasOne(x => x.Tour)
                    .WithMany(x => x.TourStops)
                    .HasForeignKey(x => x.TourId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Если удаляем станцию,
                // все TourStop, которые использовали её как остановку,
                // тоже удаляются.
                entity.HasOne(x => x.MetroStation)
                    .WithMany(x => x.TourStops)
                    .HasForeignKey(x => x.MetroStationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================================================
            // TourTheme
            // =========================================================

            modelBuilder.Entity<TourTheme>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(x => x.Name)
                    .IsUnique();
            });

            // =========================================================
            // TourThemeLink
            // Tour M:N TourTheme
            // =========================================================

            modelBuilder.Entity<TourThemeLink>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.TourId,
                    x.TourThemeId
                });

                entity.HasOne(x => x.Tour)
                    .WithMany(x => x.TourThemeLinks)
                    .HasForeignKey(x => x.TourId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.TourTheme)
                    .WithMany(x => x.TourThemeLinks)
                    .HasForeignKey(x => x.TourThemeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================================================
            // TourStopAttraction
            // TourStop M:N Attraction
            // =========================================================

            modelBuilder.Entity<TourStopAttraction>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.TourStopId,
                    x.AttractionId
                });

                entity.HasOne(x => x.TourStop)
                    .WithMany(x => x.TourStopAttractions)
                    .HasForeignKey(x => x.TourStopId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Attraction)
                    .WithMany(x => x.TourStopAttractions)
                    .HasForeignKey(x => x.AttractionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
//using MetroGuide.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//namespace MetroGuide.Data
//{
//    public class MetroGuideDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public MetroGuideDbContext(DbContextOptions<MetroGuideDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<MetroLine> MetroLines { get; set; }
//        public DbSet<MetroStation> MetroStations { get; set; }
//        public DbSet<Attraction> Attractions { get; set; }
//        public DbSet<StationAttraction> StationAttractions { get; set; }
//        public DbSet<Tour> Tours { get; set; }
//        public DbSet<TourStop> TourStops { get; set; }
//        public DbSet<TourTheme> TourThemes { get; set; }
//        public DbSet<TourThemeLink> TourThemeLinks { get; set; }
//        public DbSet<TourStopAttraction> TourStopAttractions { get; set; }
//        public DbSet<AttractionMedia> AttractionMedia { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<StationAttraction>(entity =>
//            {
//                entity.HasKey(x => new
//                {
//                    x.MetroStationId,
//                    x.AttractionId
//                });

//                entity.HasOne(x => x.MetroStation)
//                    .WithMany(x => x.StationAttractions)
//                    .HasForeignKey(x => x.MetroStationId)
//                    .OnDelete(DeleteBehavior.Cascade);

//                entity.HasOne(x => x.Attraction)
//                    .WithMany(x => x.StationAttractions)
//                    .HasForeignKey(x => x.AttractionId)
//                    .OnDelete(DeleteBehavior.Cascade);
//            });

//            modelBuilder.Entity<TourThemeLink>(entity =>
//            {
//                entity.HasKey(x => new
//                {
//                    x.TourId,
//                    x.TourThemeId
//                });

//                entity.HasOne(x => x.Tour)
//                    .WithMany(x => x.TourThemeLinks)
//                    .HasForeignKey(x => x.TourId)
//                    .OnDelete(DeleteBehavior.Cascade);

//                entity.HasOne(x => x.TourTheme)
//                    .WithMany(x => x.TourThemeLinks)
//                    .HasForeignKey(x => x.TourThemeId)
//                    .OnDelete(DeleteBehavior.Cascade);
//            });

//            modelBuilder.Entity<TourStopAttraction>(entity =>
//            {
//                entity.HasKey(x => new
//                {
//                    x.TourStopId,
//                    x.AttractionId
//                });

//                entity.HasOne(x => x.TourStop)
//                    .WithMany(x => x.TourStopAttractions)
//                    .HasForeignKey(x => x.TourStopId)
//                    .OnDelete(DeleteBehavior.Cascade);

//                entity.HasOne(x => x.Attraction)
//                    .WithMany(x => x.TourStopAttractions)
//                    .HasForeignKey(x => x.AttractionId)
//                    .OnDelete(DeleteBehavior.Cascade);
//            });

//            modelBuilder.Entity<TourStop>()
//                .HasIndex(ts => new
//                {
//                    ts.TourId,
//                    ts.StopOrder
//                })
//                .IsUnique();
//            modelBuilder.Entity<TourStop>()
//    .HasOne(x => x.Tour)
//    .WithMany(x => x.TourStops)
//    .HasForeignKey(x => x.TourId)
//    .OnDelete(DeleteBehavior.Cascade);

//            modelBuilder.Entity<MetroLine>()
//                .HasIndex(x => x.Name)
//                .IsUnique();

//            modelBuilder.Entity<TourTheme>()
//                .HasIndex(x => x.Name)
//                .IsUnique();
//            modelBuilder.Entity<MetroStation>()
//                .HasOne(x => x.MetroLine)
//                .WithMany(x => x.Stations)
//                .HasForeignKey(x => x.MetroLineId)
//                .OnDelete(DeleteBehavior.Restrict);

//        }
//    }
//}