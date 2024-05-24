namespace Blood_donate_App_Backend.Exceptions.BloodRequest_Exception
{
    public class BloodRequestDetailsNotFoundException : Exception
    {
        string message = string.Empty;
        public BloodRequestDetailsNotFoundException(int id)
        {
            message = "Blood request details not found with id: " + id;
        }

        public override string Message => message;
    }

}
