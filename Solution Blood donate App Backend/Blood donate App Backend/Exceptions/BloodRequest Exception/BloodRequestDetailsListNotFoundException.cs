namespace Blood_donate_App_Backend.Exceptions.BloodRequest_Exception
{
    public class BloodRequestDetailsListNotFoundException : Exception
    {
        string message = string.Empty;
        public BloodRequestDetailsListNotFoundException()
        {
            message = "Error in getting blood request details list from database";
        }

        public override string Message => message;

    }

}
