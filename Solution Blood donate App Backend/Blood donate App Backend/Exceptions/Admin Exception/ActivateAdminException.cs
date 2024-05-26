namespace Blood_donate_App_Backend.Exceptions.Admin_Exception
{
    public class ActivateAdminException : Exception
    {
        string message = string.Empty;

        public ActivateAdminException(int id)
        {
            message = "Error in activating the admin account with id: " + id;
        }

        public override string Message => message;
    }
}
