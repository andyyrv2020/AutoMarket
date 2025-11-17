using AutoMarket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CarListing> CarListings => Set<CarListing>();
        public DbSet<AiEstimation> AiEstimations => Set<AiEstimation>();
        public DbSet<Favorite> Favorites => Set<Favorite>();
        public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();
        public DbSet<DealerLocation> DealerLocations => Set<DealerLocation>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CarListing>().HasData(GetSeedListings());
            builder.Entity<AiEstimation>().HasData(GetSeedEstimations());
            builder.Entity<DealerLocation>().HasData(GetSeedLocations());
            builder.Entity<ChatMessage>().HasData(GetSeedChats());
        }

        private static IEnumerable<CarListing> GetSeedListings()
        {
            return new List<CarListing>
            {
                new()
                {
                    Id = 1,
                    UserId = "dealer-1",
                    Brand = "Tesla",
                    Model = "Model 3 Performance",
                    Year = 2022,
                    EngineType = "Dual Motor EV",
                    Transmission = "Automatic",
                    Mileage = 18000,
                    HorsePower = 455,
                    FuelType = "Electric",
                    Price = 52990,
                    City = "Sofia",
                    Description = "One owner, Full Self-Driving included, kept in garage.",
                    ImageUrl = "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d",
                    CreatedAt = DateTime.UtcNow.AddDays(-25)
                },
                new()
                {
                    Id = 2,
                    UserId = "dealer-2",
                    Brand = "BMW",
                    Model = "M340i xDrive",
                    Year = 2021,
                    EngineType = "3.0L Turbo I6",
                    Transmission = "Automatic",
                    Mileage = 32000,
                    HorsePower = 382,
                    FuelType = "Petrol",
                    Price = 48900,
                    City = "Plovdiv",
                    Description = "M Performance exhaust, adaptive suspension, digital cockpit.",
                    ImageUrl = "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=1200&q=80",
                    CreatedAt = DateTime.UtcNow.AddDays(-10)
                },
                new()
                {
                    Id = 3,
                    UserId = "dealer-1",
                    Brand = "Mercedes",
                    Model = "GLC 300e",
                    Year = 2023,
                    EngineType = "2.0L PHEV",
                    Transmission = "Automatic",
                    Mileage = 12000,
                    HorsePower = 315,
                    FuelType = "Hybrid",
                    Price = 55990,
                    City = "Varna",
                    Description = "Plug-in hybrid with AMG Line interior and HUD.",
                    ImageUrl = "https://images.unsplash.com/photo-1493238792000-8113da705763?auto=format&fit=crop&w=1200&q=80",
                    CreatedAt = DateTime.UtcNow.AddDays(-40)
                },
                new()
                {
                    Id = 4,
                    UserId = "dealer-3",
                    Brand = "Audi",
                    Model = "Q5 Sportback",
                    Year = 2020,
                    EngineType = "2.0L TFSI",
                    Transmission = "Automatic",
                    Mileage = 45000,
                    HorsePower = 261,
                    FuelType = "Petrol",
                    Price = 37990,
                    City = "Sofia",
                    Description = "S-line styling, panoramic roof, Virtual Cockpit.",
                    ImageUrl = "https://images.unsplash.com/photo-1492144534655-ae79c964c9d7?auto=format&fit=crop&w=1200&q=80",
                    CreatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new()
                {
                    Id = 5,
                    UserId = "dealer-2",
                    Brand = "Toyota",
                    Model = "Supra GR",
                    Year = 2020,
                    EngineType = "3.0L Turbo I6",
                    Transmission = "Automatic",
                    Mileage = 28000,
                    HorsePower = 382,
                    FuelType = "Petrol",
                    Price = 44990,
                    City = "Burgas",
                    Description = "Launch edition, JBL audio, adaptive cruise, immaculate paint.",
                    ImageUrl = "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=1200&q=80",
                    CreatedAt = DateTime.UtcNow.AddDays(-14)
                },
                new()
                {
                    Id = 6,
                    UserId = "dealer-3",
                    Brand = "Volvo",
                    Model = "XC60 Recharge",
                    Year = 2024,
                    EngineType = "PHEV T8",
                    Transmission = "Automatic",
                    Mileage = 6000,
                    HorsePower = 455,
                    FuelType = "Hybrid",
                    Price = 61900,
                    City = "Varna",
                    Description = "Pilot Assist, Bowers & Wilkins audio, one local owner.",
                    ImageUrl = "https://images.unsplash.com/photo-1489515217757-5fd1be406fef?auto=format&fit=crop&w=1200&q=80",
                    CreatedAt = DateTime.UtcNow.AddDays(-2)
                }
            };
        }

        private static IEnumerable<AiEstimation> GetSeedEstimations()
        {
            return new List<AiEstimation>
            {
                new()
                {
                    Id = 1,
                    CarListingId = 1,
                    EstimatedPrice = 51500,
                    ConfidenceLevel = 0.88,
                    ComparedListingsCount = 24,
                    DateCalculated = DateTime.UtcNow.AddDays(-1)
                },
                new()
                {
                    Id = 2,
                    CarListingId = 2,
                    EstimatedPrice = 47500,
                    ConfidenceLevel = 0.82,
                    ComparedListingsCount = 18,
                    DateCalculated = DateTime.UtcNow.AddDays(-2)
                },
                new()
                {
                    Id = 3,
                    CarListingId = 3,
                    EstimatedPrice = 54800,
                    ConfidenceLevel = 0.9,
                    ComparedListingsCount = 21,
                    DateCalculated = DateTime.UtcNow.AddDays(-3)
                }
            };
        }

        private static IEnumerable<DealerLocation> GetSeedLocations()
        {
            return new List<DealerLocation>
            {
                new() { Id = 1, UserId = "dealer-1", Latitude = 42.6977, Longitude = 23.3219, Address = "Sofia, bul. Tsarigradsko shose 115" },
                new() { Id = 2, UserId = "dealer-2", Latitude = 42.1354, Longitude = 24.7453, Address = "Plovdiv, ul. Brezovsko shose 160" },
                new() { Id = 3, UserId = "dealer-3", Latitude = 43.2141, Longitude = 27.9147, Address = "Varna, bul. Vladislav Varnenchik 258" }
            };
        }

        private static IEnumerable<ChatMessage> GetSeedChats()
        {
            return new List<ChatMessage>
            {
                new() { Id = 1, SenderId = "dealer-1", ReceiverId = "buyer-1", Message = "Здравейте! Колата е налична и може да се тества тази седмица.", Timestamp = DateTime.UtcNow.AddHours(-5) },
                new() { Id = 2, SenderId = "buyer-1", ReceiverId = "dealer-1", Message = "Чудесно, интересува ме Tesla-та. Може ли неделя?", Timestamp = DateTime.UtcNow.AddHours(-4) },
                new() { Id = 3, SenderId = "dealer-1", ReceiverId = "buyer-1", Message = "Да, запазвам ви слот в 14:00. Ще изпратя локация.", Timestamp = DateTime.UtcNow.AddHours(-3) }
            };
        }
    }
}
