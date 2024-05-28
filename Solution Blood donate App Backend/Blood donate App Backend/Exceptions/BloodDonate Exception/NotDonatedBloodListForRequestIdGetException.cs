namespace Blood_donate_App_Backend.Exceptions.BloodDonate_Exception
{
    public class NotDonatedBloodListForRequestIdGetException : Exception
    {
        string message = string.Empty;

        public NotDonatedBloodListForRequestIdGetException(int requestId)
        {
            message = "Error in getting Not donated Blood List for requestID : " + requestId;
        }

        public override string Message => message;
    }
}
