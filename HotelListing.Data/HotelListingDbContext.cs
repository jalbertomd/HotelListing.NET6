using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext: IdentityDbContext<ApiUser>
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());

            //modelBuilder.Entity<Country>().HasData(
            //    new Country { Id = 1, Name = "Mexico", ShortName = "MX" },
            //    new Country { Id = 2, Name = "Brazil", ShortName = "BR" },
            //    new Country { Id = 3, Name = "United States", ShortName = "US" });

            //modelBuilder.Entity<Hotel>().HasData(
            //    new Hotel { Id = 1, Name = "Hotel On", Address = "Calle 1", Rating = 5.0, CountryId = 1 },
            //    new Hotel { Id = 2, Name = "Hotel Inn", Address = "Calle 2", Rating = 4.5, CountryId = 2 },
            //    new Hotel { Id = 3, Name = "Hotel Off", Address = "Calle 3", Rating = 3.9, CountryId = 3 });
        }
    }
}
