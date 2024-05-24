namespace Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception
{
    public class UserAuthDetailsNotUpdateException : Exception
    {
        string message = string.Empty;

        public UserAuthDetailsNotUpdateException()
        {
            message = "Error in updating the user auth details in database";
        }

        public override string Message => message;
    }

}
