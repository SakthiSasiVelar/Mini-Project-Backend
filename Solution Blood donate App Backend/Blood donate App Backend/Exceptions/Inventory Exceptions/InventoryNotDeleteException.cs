namespace Blood_donate_App_Backend.Exceptions.Inventory_Exceptions
{
    public class InventoryNotDeleteException : Exception
    {
        string message = string.Empty;

        public InventoryNotDeleteException()
        {
            message = "Error in deleting inventory details in database";
        }

        public override string Message => message;
    }
}
