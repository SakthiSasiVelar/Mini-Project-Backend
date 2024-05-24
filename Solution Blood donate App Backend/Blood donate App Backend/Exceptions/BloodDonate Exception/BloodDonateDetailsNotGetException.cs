namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class BloodDonateDetailsNotGetException : Exception
    {
        string message = string.Empty;

        public BloodDonateDetailsNotGetException()
        {
            message = "Error in getting blood donate details from database";
        }

        public override string Message => message;
    }
}
