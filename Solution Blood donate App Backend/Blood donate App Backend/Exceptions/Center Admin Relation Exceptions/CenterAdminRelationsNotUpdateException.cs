namespace Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions
{
    public class CenterAdminRelationsNotUpdateException : Exception
    {
        string message = string.Empty;

        public CenterAdminRelationsNotUpdateException()
        {
            message = "Error in updating the center admin relation details in database";
        }

        public override string Message => message;
    }
}
