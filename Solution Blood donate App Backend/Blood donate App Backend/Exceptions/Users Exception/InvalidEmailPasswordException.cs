namespace Blood_donate_App_Backend.Exceptions.Users_Exception
{
    public class InvalidEmailPasswordException : Exception
    {
        string message = string.Empty;

        public InvalidEmailPasswordException() {
            message = "Invalid Email and Password";
        }

        public override string Message => message;
    }
}
