namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class BloodDonationCenterNotUpdateException : Exception
    {
        string message = string.Empty;

        public BloodDonationCenterNotUpdateException()
        {
            message = "Error in updating the blood donation details in database";
        }

        public override string Message => message;
    }
}
