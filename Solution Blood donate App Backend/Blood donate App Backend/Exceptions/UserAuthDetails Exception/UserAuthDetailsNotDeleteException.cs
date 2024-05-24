namespace Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception
{
    public class UserAuthDetailsNotDeleteException : Exception
    {
        string message = string.Empty;

        public UserAuthDetailsNotDeleteException()
        {
            message = "Error in deleting user auth details in database";
        }

        public override string Message => message;
    }

}
