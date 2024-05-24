namespace Blood_donate_App_Backend.Exceptions.Inventory_Exceptions
{
    public class InventoryListNotFoundException : Exception
    {
        string message = string.Empty;
        public InventoryListNotFoundException()
        {
            message = "Error in getting inventory details list from database";
        }

        public override string Message => message;

    }
}
