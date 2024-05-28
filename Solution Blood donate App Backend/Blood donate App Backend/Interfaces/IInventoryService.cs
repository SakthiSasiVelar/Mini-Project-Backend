using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IInventoryService
    { 
        public Task<InventoryAddReturnDTO> AddInventory(InventoryAddDTO inventoryAddDTO);
    }
}
