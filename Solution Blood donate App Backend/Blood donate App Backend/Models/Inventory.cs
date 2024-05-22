namespace Blood_donate_App_Backend.Models
{
    public class Inventory
    {
        public int Id { get; set; } 

        public int CenterId { get; set; }

        public DonationCenter Center { get; set; }

        public int DonorId { get; set; }

        public User Donor { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string Units { get; set; }

        public DateTime CollectedDateTime { get; set; }

        public DateTime ExpiryDateTime { get; set; }

        public string StorageLocation { get; set; }

        public bool AvailableStatus { get; set; }
    }
}
