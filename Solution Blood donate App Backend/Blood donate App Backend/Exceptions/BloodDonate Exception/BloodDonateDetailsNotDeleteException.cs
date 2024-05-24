namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class BloodDonateDetailsNotDeleteException : Exception
    {
        string message = string.Empty;

        public BloodDonateDetailsNotDeleteException()
        {
            message = "Error in deleting blood donate details in database";
        }

        public override string Message => message;
    }
}
