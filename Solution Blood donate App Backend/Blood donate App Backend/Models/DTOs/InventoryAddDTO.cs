using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class InventoryAddDTO
    {
        [Required(ErrorMessage = "Center Id is required")]
        public int CenterId { get; set; }

        [Required(ErrorMessage = "Donor Id is required")]
        public int DonorId { get; set; }

        [Required(ErrorMessage = "BloodType is required")]
        public string BloodType { get; set; }

        [Required(ErrorMessage = "RhFactor is required")]
        public string RhFactor { get; set; }

        [Required(ErrorMessage = "Units is required")]
        public string Units { get; set; }

        [Required(ErrorMessage = "Collected DateTime is required")]
        public DateTime CollectedDateTime { get; set; }

        [Required(ErrorMessage = "Expiry DateTime is required")]
        public DateTime ExpiryDateTime { get; set; }

        [Required(ErrorMessage = "Storage location is required")]
        public string StorageLocation { get; set; }
    }
}
