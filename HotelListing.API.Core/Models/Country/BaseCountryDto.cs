using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Core.Models.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country name is too long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Short country name is too long.")]
        public string ShortName { get; set; }
    }
}
