namespace Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception
{
    public class GetDonationCenterBloodUnitsByIdException : Exception
    {
        string message = string.Empty;

        public GetDonationCenterBloodUnitsByIdException(int centerId)
        {
            message = "Error in getting blood units from donation center of id: " + centerId;
        }

        public override string Message => message;

    }
}
