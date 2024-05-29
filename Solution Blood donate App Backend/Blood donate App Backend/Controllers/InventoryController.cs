using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private const string CenterAdmin = "CenterAdmin";
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [Authorize(Roles = CenterAdmin)]
        [HttpPost("inventory/addInventory")]
        [ProducesResponseType(typeof(SuccessResponseModel<InventoryAddReturnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InventoryAddReturnDTO>>  AddInventory([FromBody]InventoryAddDTO inventoryAddDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ValidationErrorModel(400, ModelState));
                }
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
