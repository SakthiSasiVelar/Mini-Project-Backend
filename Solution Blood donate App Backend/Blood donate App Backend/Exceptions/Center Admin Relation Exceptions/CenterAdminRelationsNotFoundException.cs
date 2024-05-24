namespace Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions
{
    public class CenterAdminRelationsNotFoundException : Exception
    {
        string message = string.Empty;
        public CenterAdminRelationsNotFoundException(int id)
        {
            message = "Center admin relation details not found with id: " + id;
        }

        public override string Message => message;
    }
}
