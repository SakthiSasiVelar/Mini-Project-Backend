namespace Blood_donate_App_Backend.Exceptions.Users_Exception
{
    public class UserAuthDetailsNotFoundByEmailException : Exception
    {
        string message = string.Empty;

        public UserAuthDetailsNotFoundByEmailException(string email)
        {
            message = "Error in getting user auth details with email: " + email;
        }

        public override string Message => message;
    }
}
