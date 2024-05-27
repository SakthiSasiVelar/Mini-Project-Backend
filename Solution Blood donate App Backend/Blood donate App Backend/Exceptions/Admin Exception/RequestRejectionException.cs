namespace Blood_donate_App_Backend.Exceptions.Admin_Exception
{
    public class RequestRejectionException : Exception
    {
        string message = string.Empty;

        public RequestRejectionException(int id)
        {
            message = "Error in rejecting the request with id :" + id;
        }

        public override string Message => message;
    }
}
