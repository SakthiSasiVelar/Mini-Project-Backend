namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class NotdonatedBloodListForCenterIdException : Exception
    {
        string message = string.Empty;

        public NotdonatedBloodListForCenterIdException(int centerId)
        {
            message = "Error in getting Not donated Blood List for center id: " + centerId;
        }

        public override string Message => message;
    }
}
