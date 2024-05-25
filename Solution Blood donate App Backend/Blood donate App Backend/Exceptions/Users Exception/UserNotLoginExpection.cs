namespace Blood_donate_App_Backend.Exceptions.Users_Exception
{
    public class UserNotLoginExpection : Exception
    {
        string message = string.Empty;

        public UserNotLoginExpection() {
            message = "Error during login the user";
        }

        public override string Message => message;
    }
}
