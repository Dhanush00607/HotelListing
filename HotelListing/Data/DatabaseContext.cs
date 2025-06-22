using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    ShortName = "IND"
                },
                new Country
                {
                    Id = 2,
                    Name = "Scotland",
                    ShortName = "SC"
                },
                new Country
                {
                    Id = 3,
                    Name = "Bali",
                    ShortName = "IN"
                }


              );
            builder.Entity<Hotel>().HasData(
             new Hotel
             {
                 Id = 1,
                 Name = "Taj Hotel",
                 Address = "Mumbai",
                 CountryId = 1,
                 Rating = 5
             },
             new Hotel
             {
                 Id = 2,
                 Name = "JW Mariot Hotel",
                 Address = "Bangalore",
                 CountryId = 2,
                 Rating = 4.5
             },
             new Hotel
             {
                 Id = 3,
                 Name = "Tata Hotel",
                 Address = "Chennai",
                 CountryId = 3,
                 Rating = 4.5
             }
          );

        }

    }
}
