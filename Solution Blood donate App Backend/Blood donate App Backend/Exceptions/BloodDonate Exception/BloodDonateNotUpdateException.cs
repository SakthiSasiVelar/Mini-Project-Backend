namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class BloodDonateNotUpdateException : Exception
    {
        string message = string.Empty;

        public BloodDonateNotUpdateException()
        {
            message = "Error in updating the blood donate details in database";
        }

        public override string Message => message;
    }
}
