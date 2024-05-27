namespace Blood_donate_App_Backend.Models.DTOs
{
    public class DonateBloodForRequestReturnDTO
    {
        public int DonationId { get; set; }

        public int DonatedUserId { get; set; }

        public string DonationType { get; set; }

        public int RequestId { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string DonationStatus { get; set; }

        public string UnitsDonated { get; set; }

        public DateTime DonateDateTime { get; set; }
    }
}
