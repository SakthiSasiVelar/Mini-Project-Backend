namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class ApproveDonationException : Exception
    {
        string message = string.Empty;

        public ApproveDonationException(int id)
        {
            message = "Error in approving the blood donation details of id: " + id;
        }

        public override string Message => message;

    }
}
