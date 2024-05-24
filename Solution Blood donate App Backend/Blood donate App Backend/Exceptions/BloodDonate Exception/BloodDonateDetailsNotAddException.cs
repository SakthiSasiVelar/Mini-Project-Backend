namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class BloodDonateDetailsNotAddException : Exception
    {
        string message = string.Empty;
        public BloodDonateDetailsNotAddException()
        {
            message = "Error in adding blood donate details to database";
        }

        public override string Message => message;

    }
}
