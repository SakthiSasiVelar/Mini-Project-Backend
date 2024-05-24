namespace Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception
{
    public class UserAuthDetailsNotGetException : Exception
    {
        string message = string.Empty;

        public UserAuthDetailsNotGetException()
        {
            message = "Error in getting user auth details from database";
        }

        public override string Message => message;
    }

}
