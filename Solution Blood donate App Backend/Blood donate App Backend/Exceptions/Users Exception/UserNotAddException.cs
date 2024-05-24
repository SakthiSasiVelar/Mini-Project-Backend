namespace Blood_donate_App_Backend.Exceptions
{
    public class UserNotAddException : Exception
    {
        string message = string.Empty;
        public UserNotAddException()
        {
            message = "Error in adding user to database";
        }

        public override string Message => message;
    }
}
