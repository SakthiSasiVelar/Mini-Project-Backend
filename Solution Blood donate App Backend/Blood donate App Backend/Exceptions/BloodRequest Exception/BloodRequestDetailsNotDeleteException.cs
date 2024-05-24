namespace Blood_donate_App_Backend.Exceptions.BloodRequest_Exception
{
    public class BloodRequestDetailsNotDeleteException : Exception
    {
        string message = string.Empty;

        public BloodRequestDetailsNotDeleteException()
        {
            message = "Error in deleting blood request details in database";
        }

        public override string Message => message;
    }

}
