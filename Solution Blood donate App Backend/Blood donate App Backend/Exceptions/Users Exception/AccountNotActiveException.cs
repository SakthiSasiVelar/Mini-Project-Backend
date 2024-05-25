namespace Blood_donate_App_Backend.Exceptions.Users_Exception
{
    public class AccountNotActiveException : Exception
    {
        string message = string.Empty;

        public AccountNotActiveException()
        {
            message = "Your account is not activated";
        }

        public override string Message => message;
    }
}
