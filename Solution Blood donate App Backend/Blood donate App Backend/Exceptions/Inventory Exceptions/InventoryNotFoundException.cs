namespace Blood_donate_App_Backend.Exceptions.Inventory_Exceptions
{
    public class InventoryNotFoundException : Exception
    {
        string message = string.Empty;
        public InventoryNotFoundException(int id)
        {
            message = "Inventory details not found with id: " + id;
        }

        public override string Message => message;
    }
}
