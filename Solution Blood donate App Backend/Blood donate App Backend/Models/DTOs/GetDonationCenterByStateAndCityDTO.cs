using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class GetDonationCenterByStateAndCityDTO
    {
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
    }
}
