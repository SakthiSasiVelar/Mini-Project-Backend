namespace Blood_donate_App_Backend.Models.DTOs
{
    public class DonationCenterAllBloodUnitsReturnDTO
    {
        public int CenterId { get; set; }

        public double APositive {  get; set; }

        public double ANegative { get; set; }

        public double BPositive { get; set; }

        public double BNegative { get; set; }

        public double ABPositive { get; set; }

        public double ABNegative { get; set; }

        public double OPositive { get; set; }

        public double ONegative { get; set;}
    }
}
