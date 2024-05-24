namespace Blood_donate_App_Backend.Exceptions
{
    public class UserNotUpdateException : Exception
    {
        string message = string.Empty;

        public UserNotUpdateException() {
            message = "Error in updating the user in database";
        }

        public override string Message => message;
    }
}
