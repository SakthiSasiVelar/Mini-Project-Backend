namespace Blood_donate_App_Backend.Models.DTOs
{
    public class DonateBloodForCenterDTO
    {
        public int UserId { get; set; }

        public int CenterId { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string UnitsDonated { get; set; }

        public DateTime DonateDateTime { get; set; }
    }
}
