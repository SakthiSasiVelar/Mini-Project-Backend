using Blood_donate_App_Backend.Exceptions.Inventory_Exceptions;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;


namespace Blood_donate_App_Backend.Services
{
    public class InventoryServiceBL : IInventoryService
    {
        private readonly IRepository<int, Inventory> _inventoryRepository;

        public InventoryServiceBL(IRepository<int, Inventory> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<InventoryAddReturnDTO> AddInventory(InventoryAddDTO inventoryAddDTO)
        {
            try
            {
                var inventoryDetails = await new InventoryAddDTOMapper().InventoryAddDTOtoInventory(inventoryAddDTO);
                var addedInventory = await _inventoryRepository.Add(inventoryDetails);
                return await new InventoryMapper().InventorytoInventoryAddReturnDTO(addedInventory);
            }
            catch(Exception ex)
            {
                throw new InventoryNotAddException();
            }
        }
    }
}
