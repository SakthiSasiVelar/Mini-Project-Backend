using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class InventoryAddDTOMapper
    {
        public async Task<Inventory> InventoryAddDTOtoInventory(InventoryAddDTO inventoryAddDTO)
        {
            Inventory inventory = new Inventory()
            {
                CenterId = inventoryAddDTO.CenterId,
                DonorId = inventoryAddDTO.DonorId,
                Units = inventoryAddDTO.Units,
                CollectedDateTime = inventoryAddDTO.CollectedDateTime,
                ExpiryDateTime = inventoryAddDTO.ExpiryDateTime,
                StorageLocation = inventoryAddDTO.StorageLocation,
                AvailableStatus = true
            };
            var BloodType = inventoryAddDTO.BloodType.ToLower();
            if (BloodType == "a") inventory.BloodType = EnumClass.BloodType.A.ToString();
            else if (BloodType == "b") inventory.BloodType = EnumClass.BloodType.B.ToString();
            else if (BloodType == "ab") inventory.BloodType = EnumClass.BloodType.AB.ToString();
            else if (BloodType == "o") inventory.BloodType = EnumClass.BloodType.O.ToString();

            var RhFactor = inventoryAddDTO.RhFactor.ToLower();
            if (RhFactor == "positive") inventory.RhFactor = EnumClass.RhFactor.positive.ToString();
            else if (RhFactor == "negative") inventory.RhFactor = EnumClass.RhFactor.negative.ToString();
            return inventory;
        }
    }
}
