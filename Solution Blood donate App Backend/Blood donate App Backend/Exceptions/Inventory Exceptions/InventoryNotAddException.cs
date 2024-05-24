namespace Blood_donate_App_Backend.Exceptions.Inventory_Exceptions
{
    public class InventoryNotAddException : Exception
    {
        string message = string.Empty;
        public InventoryNotAddException()
        {
            message = "Error in adding inventory details to database";
        }

        public override string Message => message;

    }
}
