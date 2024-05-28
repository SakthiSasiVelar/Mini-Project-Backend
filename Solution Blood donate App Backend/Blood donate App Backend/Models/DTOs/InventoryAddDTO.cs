namespace Blood_donate_App_Backend.Models.DTOs
{
    public class InventoryAddDTO
    { 
        public int CenterId { get; set; }

        public int DonorId { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string Units { get; set; }

        public DateTime CollectedDateTime { get; set; }

        public DateTime ExpiryDateTime { get; set; }

        public string StorageLocation { get; set; }
    }
}
