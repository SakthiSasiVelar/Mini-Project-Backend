namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class DonationCenterNotavailableException :Exception
    {
        string message = string.Empty;
        public DonationCenterNotavailableException(int id)
        {
            message = "Donation center not available for id: " + id;
        }

        public override string Message => message;
    }
}
