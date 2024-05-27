namespace Blood_donate_App_Backend.Models.DTOs
{
    public class DonateBloodForRequestDTO
    {
        public int UserId { get; set; }

        public int RequestId { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string UnitsDonated { get; set; }

        public DateTime DonateDateTime { get; set; }
    }
}
