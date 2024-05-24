namespace Blood_donate_App_Backend.Exceptions.Inventory_Exceptions
{
    public class InventoryNotUpdateException : Exception
    {
        string message = string.Empty;

        public InventoryNotUpdateException()
        {
            message = "Error in updating the inventory details in database";
        }

        public override string Message => message;
    }
}
