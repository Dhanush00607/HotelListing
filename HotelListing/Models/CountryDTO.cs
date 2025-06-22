using HotelListing.Data;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CreateCountryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is T00 Long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Country Name is T00 Short")]
        public string ShortName { get; set; }
    }
    public class CountryDTO : CreateCountryDTO

    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }

    }  
}
