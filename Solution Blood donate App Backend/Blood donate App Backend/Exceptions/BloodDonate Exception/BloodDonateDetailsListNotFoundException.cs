namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class BloodDonateDetailsListNotFoundException : Exception
    {
        string message = string.Empty;
        public BloodDonateDetailsListNotFoundException()
        {
            message = "Error in getting blood donate details list from database";
        }

        public override string Message => message;

    }
}
