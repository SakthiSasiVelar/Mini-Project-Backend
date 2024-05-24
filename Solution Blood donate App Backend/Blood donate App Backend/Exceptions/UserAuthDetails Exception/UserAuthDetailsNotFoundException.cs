namespace Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception
{
    public class UserAuthDetailsNotFoundException : Exception
    {
        string message = string.Empty;
        public UserAuthDetailsNotFoundException(int id)
        {
            message = "User auth details not found with id: " + id;
        }

        public override string Message => message;
    }
}
