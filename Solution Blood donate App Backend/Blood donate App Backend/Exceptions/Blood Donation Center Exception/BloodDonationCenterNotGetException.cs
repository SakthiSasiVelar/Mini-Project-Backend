namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class BloodDonationCenterNotGetException : Exception
    {
        string message = string.Empty;

        public BloodDonationCenterNotGetException()
        {
            message = "Error in getting blood donation center details from database";
        }

        public override string Message => message;
    }
}
