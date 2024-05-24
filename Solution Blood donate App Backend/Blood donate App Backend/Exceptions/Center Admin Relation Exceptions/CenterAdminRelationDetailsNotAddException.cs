namespace Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions
{
    public class CenterAdminRelationDetailsNotAddException : Exception
    {
        string message = string.Empty;
        public CenterAdminRelationDetailsNotAddException()
        {
            message = "Error in adding center admin relation details to database";
        }

        public override string Message => message;

    }
}
