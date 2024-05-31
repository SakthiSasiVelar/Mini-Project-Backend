using System.ComponentModel;

namespace Blood_donate_App_Backend.Exceptions.Admin_Exception
{
    public class RequestApprovalException : Exception
    {
        string message = string.Empty;

        public RequestApprovalException(int id)
        {
            message = "Error in approving the request with id: " + id;
        }

        public override string Message => message;
    }
}
