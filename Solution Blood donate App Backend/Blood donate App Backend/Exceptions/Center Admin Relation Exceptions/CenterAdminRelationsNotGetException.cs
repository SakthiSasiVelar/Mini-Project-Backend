namespace Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions
{
    public class CenterAdminRelationsNotGetException : Exception
    {
        string message = string.Empty;

        public CenterAdminRelationsNotGetException()
        {
            message = "Error in getting center admin relation details from database";
        }

        public override string Message => message;
    }
}
