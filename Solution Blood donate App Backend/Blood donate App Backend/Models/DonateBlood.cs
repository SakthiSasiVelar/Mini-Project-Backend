namespace Blood_donate_App_Backend.Models
{
    public class DonateBlood
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string DonationType { get; set; }

        public int? CenterId { get; set; }

        public DonationCenter DonatedInCenter { get; set; }

        public int? RequestId { get; set; }

        public RequestBlood DonatedToRequester { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string DonationStatus { get; set; }

        public string UnitsDonated { get; set; }

        public DateTime DonateDateTime { get; set; }

    }
}
