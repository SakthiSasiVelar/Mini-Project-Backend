namespace Blood_donate_App_Backend.Exceptions
{
    public class UserNotFoundException : Exception
    {
        string message = string.Empty;
        public UserNotFoundException(int id) {
            message = "User not found with id: " + id;
        }

        public override string Message => message;
    }
}
