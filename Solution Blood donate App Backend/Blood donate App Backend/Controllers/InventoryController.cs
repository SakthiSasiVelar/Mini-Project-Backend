using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost("inventory/addInventory")]
        public async Task<ActionResult<InventoryAddReturnDTO>>  AddInventory([FromBody]InventoryAddDTO inventoryAddDTO)
        {
            try
            {
                var result = await _inventoryService.AddInventory(inventoryAddDTO);
                var response = new SuccessResponseModel<InventoryAddReturnDTO>(201, "Inventory details added successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500,new ErrorModel(500, ex.Message));
            }
        }
    }
}
