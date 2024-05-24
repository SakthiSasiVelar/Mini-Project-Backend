namespace Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions
{
    public class CenterAdminRelationsNotDeleteException : Exception
    {
        string message = string.Empty;

        public CenterAdminRelationsNotDeleteException()
        {
            message = "Error in deleting center admin relation details in database";
        }

        public override string Message => message;
    }
}
