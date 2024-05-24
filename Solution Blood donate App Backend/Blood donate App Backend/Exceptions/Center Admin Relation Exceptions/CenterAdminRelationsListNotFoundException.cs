namespace Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions
{
    public class CenterAdminRelationsListNotFoundException : Exception
    {
        string message = string.Empty;
        public CenterAdminRelationsListNotFoundException()
        {
            message = "Error in getting center admin relation details list from database";
        }

        public override string Message => message;

    }
}
