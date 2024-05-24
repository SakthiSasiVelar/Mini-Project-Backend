namespace Blood_donate_App_Backend.Exceptions.Request_Exception
{
    public class BloodRequestDetailsNotAddException : Exception
    {
        string message = string.Empty;
        public BloodRequestDetailsNotAddException()
        {
            message = "Error in adding blood request details to database";
        }

        public override string Message => message;

    }

}
