namespace Blood_donate_App_Backend.Exceptions
{
    public class UserNotDeleteException : Exception
    {
        string message = string.Empty;

        public UserNotDeleteException() {
            message = "Error in deleting user in database";
        }

        public override string Message => message;
    }
}
