
using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class DonationCenterDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Pin code is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid Indian postal code. It must be a 6-digit number.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Contact number must be a 10-digit number.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "operating hours is required")]
        public string OperatingHours { get; set; }
    }
}
