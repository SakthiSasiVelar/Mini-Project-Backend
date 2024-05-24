namespace Blood_donate_App_Backend.Exceptions
{
    public class UsersListNotFoundException : Exception
    {
        string message = string.Empty;
        public UsersListNotFoundException() {
            message = "Error in getting users list from database";
        }

        public override string Message => message;
        
    }
}
