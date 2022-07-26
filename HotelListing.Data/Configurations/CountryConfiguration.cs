using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country { Id = 1, Name = "Mexico", ShortName = "MX" },
                new Country { Id = 2, Name = "Brazil", ShortName = "BR" },
                new Country { Id = 3, Name = "United States", ShortName = "US" },
                new Country { Id = 6, Name = "Netherlands", ShortName = "NL" },
                new Country { Id = 7, Name = "Canada", ShortName = "CA" }
            );
        }
    }
}
