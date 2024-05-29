using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class DonateBloodForCenterDTO
    {
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Center Id is required")]
        public int CenterId { get; set; }

        [Required(ErrorMessage = "Blood type is required")]
        public string BloodType { get; set; }

        [Required(ErrorMessage = "Rh factor is required")]
        public string RhFactor { get; set; }

        [Required(ErrorMessage = "Units Donated is required")]
        public string UnitsDonated { get; set; }

        [Required(ErrorMessage = "DonateDateTime is required")]
        public DateTime DonateDateTime { get; set; }
    }
}
