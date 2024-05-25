namespace Blood_donate_App_Backend.Exceptions.Users_Exception
{
    public class UserNotRegisterException : Exception
    {
        string message = string.Empty;

        public UserNotRegisterException() {
            message = "Error in registering the user";
        }

        public override string Message => message;
    }
}
