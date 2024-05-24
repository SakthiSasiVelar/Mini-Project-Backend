namespace Blood_donate_App_Backend.Exceptions.BloodRequest_Exception
{
    public class BloodRequestDetailsNotGetException : Exception
    {
        string message = string.Empty;

        public BloodRequestDetailsNotGetException()
        {
            message = "Error in getting blood request details from database";
        }

        public override string Message => message;
    }
}
