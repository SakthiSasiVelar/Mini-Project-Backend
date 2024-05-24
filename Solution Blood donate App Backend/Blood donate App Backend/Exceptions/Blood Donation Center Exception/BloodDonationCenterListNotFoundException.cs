namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class BloodDonationCenterListNotFoundException : Exception
    {
        string message = string.Empty;
        public BloodDonationCenterListNotFoundException()
        {
            message = "Error in getting blood donation center details list from database";
        }

        public override string Message => message;

    }
}
