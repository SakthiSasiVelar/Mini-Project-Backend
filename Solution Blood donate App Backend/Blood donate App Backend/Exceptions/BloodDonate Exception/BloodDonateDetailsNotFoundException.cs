namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class BloodDonateDetailsNotFoundException : Exception
    {
        string message = string.Empty;
        public BloodDonateDetailsNotFoundException(int id)
        {
            message = "Blood donate details not found with id: " + id;
        }

        public override string Message => message;
    }
}
