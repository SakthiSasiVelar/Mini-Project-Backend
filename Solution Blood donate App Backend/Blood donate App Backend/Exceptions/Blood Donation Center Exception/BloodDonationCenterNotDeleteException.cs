namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class BloodDonationCenterNotDeleteException : Exception
    {
        string message = string.Empty;

        public BloodDonationCenterNotDeleteException()
        {
            message = "Error in deleting blood donation center details in database";
        }

        public override string Message => message;
    }
}
