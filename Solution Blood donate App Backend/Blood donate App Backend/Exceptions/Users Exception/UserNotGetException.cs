namespace Blood_donate_App_Backend.Exceptions
{
    public class UserNotGetException : Exception
    {
        string message = string.Empty;

        public UserNotGetException() {
            message = "Error in getting user from database";
        }

        public override string Message => message;
    }
}
