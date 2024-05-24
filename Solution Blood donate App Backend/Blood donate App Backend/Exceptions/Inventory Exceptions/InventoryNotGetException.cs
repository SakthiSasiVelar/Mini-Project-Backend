namespace Blood_donate_App_Backend.Exceptions.Inventory_Exceptions
{
    public class InventoryNotGetException : Exception
    {
        string message = string.Empty;

        public InventoryNotGetException()
        {
            message = "Error in getting inventory details from database";
        }

        public override string Message => message;
    }
}
