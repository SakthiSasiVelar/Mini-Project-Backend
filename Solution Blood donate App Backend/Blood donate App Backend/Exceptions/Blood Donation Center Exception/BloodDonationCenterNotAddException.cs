namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class BloodDonationCenterNotAddException : Exception
    {
        string message = string.Empty;
        public BloodDonationCenterNotAddException()
        {
            message = "Error in adding blood donation center  details to database";
        }

        public override string Message => message;

    }
}
