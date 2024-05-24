namespace Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception
{
    public class UserAuthDetailsListNotFoundException : Exception
    {
        string message = string.Empty;
        public UserAuthDetailsListNotFoundException()
        {
            message = "Error in getting users auth details list from database";
        }

        public override string Message => message;

    }

}
