namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class BloodDonationCenterNotFoundException : Exception
    {
        string message = string.Empty;
        public BloodDonationCenterNotFoundException(int id)
        {
            message = "Blood donation center details not found with id: " + id;
        }

        public override string Message => message;
    }
}
