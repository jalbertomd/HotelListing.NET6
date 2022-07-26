using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Hotel On", Address = "Calle 1", Rating = 5.0, CountryId = 1 },
                new Hotel { Id = 2, Name = "Hotel Inn", Address = "Calle 2", Rating = 4.5, CountryId = 2 },
                new Hotel { Id = 3, Name = "Hotel Off", Address = "Calle 3", Rating = 3.9, CountryId = 3 }
            );
        }
    }
}
