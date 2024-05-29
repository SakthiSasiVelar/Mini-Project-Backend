namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class GetDonationCenterByStateAndCityException : Exception
    {
        string message = string.Empty;

        public GetDonationCenterByStateAndCityException()
        {
            message = "error in getting donation center list by state and city";
        }

        public override string Message => message;
    }
}
