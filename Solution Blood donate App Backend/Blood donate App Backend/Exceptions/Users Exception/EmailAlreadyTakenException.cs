namespace Blood_donate_App_Backend.Exceptions.Users_Exception
{
    public class EmailAlreadyTakenException : Exception
    {
        string messsage = string.Empty;

        public EmailAlreadyTakenException()
        {
            messsage = "The email address is already Taken";
        }

        public override string Message => messsage;
    }
}
