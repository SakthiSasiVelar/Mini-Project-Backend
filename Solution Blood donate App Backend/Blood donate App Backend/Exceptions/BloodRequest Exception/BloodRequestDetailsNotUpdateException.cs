namespace Blood_donate_App_Backend.Exceptions.BloodRequest_Exception
{
    public class BloodRequestDetailsNotUpdateException : Exception
    {
        string message = string.Empty;

        public BloodRequestDetailsNotUpdateException()
        {
            message = "Error in updating the blood request details in database";
        }

        public override string Message => message;
    }
}
