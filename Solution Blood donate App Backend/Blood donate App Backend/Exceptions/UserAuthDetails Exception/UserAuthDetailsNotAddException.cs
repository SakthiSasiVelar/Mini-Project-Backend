namespace Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception
{
    public class UserAuthDetailsNotAddException : Exception
    {
        string message = string.Empty;

        public UserAuthDetailsNotAddException()
        {
            message = "Error in adding user auth details to database";
        }

        public override string Message => message;
    }
}
