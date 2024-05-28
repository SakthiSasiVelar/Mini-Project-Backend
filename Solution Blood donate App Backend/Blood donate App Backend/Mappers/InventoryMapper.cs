using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class InventoryMapper
    {
        public async Task<InventoryAddReturnDTO> InventorytoInventoryAddReturnDTO(Inventory inventory)
        {
            InventoryAddReturnDTO inventoryAddReturnDTO = new InventoryAddReturnDTO()
            {
                InventoryId = inventory.Id,
                CenterId = inventory.CenterId,
                DonorId = inventory.DonorId,
                BloodType = inventory.BloodType,
                RhFactor = inventory.RhFactor,
                Units = inventory.Units,
                CollectedDateTime = inventory.CollectedDateTime,
                ExpiryDateTime = inventory.ExpiryDateTime,
                AvailableStatus = inventory.AvailableStatus,
                StorageLocation = inventory.StorageLocation,
            };
            return inventoryAddReturnDTO;

        }
    }
}
