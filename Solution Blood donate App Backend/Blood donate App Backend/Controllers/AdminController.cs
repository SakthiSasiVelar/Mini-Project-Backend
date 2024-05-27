using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private const string AdminRole = "Admin";

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Roles = AdminRole)]
        [HttpPut("admin/activateAdmin/{id}")]
        [ProducesResponseType(typeof(ActivateAdminReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ActivateAdminReturnDTO>> ActivateAdmin(int id)
        {
            try
            {
                var result = await _adminService.ActivateAdmin(id);
                var response = new SuccessResponseModel<ActivateAdminReturnDTO>(200, "Account has been activated successfully", result);
                return Ok(response);
            }
            catch(UserNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(UserAuthDetailsNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }


        [Authorize(Roles = AdminRole)]
        [HttpPut("request/approveRequest/{id}")]
        [ProducesResponseType(typeof(ApprovedBloodRequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApprovedBloodRequestReturnDTO>> ApproveRequest(int id)
        {
            try
            {
                var result = await _adminService.ApproveRequest(id);
                var response = new SuccessResponseModel<ApprovedBloodRequestReturnDTO>(200, "Request approved successfully", result);
                return Ok(response);
            }
            catch (BloodRequestDetailsNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500,new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = AdminRole)]
        [HttpPut("request/rejectRequest/{id}")]
        [ProducesResponseType(typeof(RejectBloodRequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RejectBloodRequestReturnDTO>> RejectRequest([FromBody] RejectBloodRequestDTO rejectBloodRequestDTO )
        {
            try
            {
                var result = await _adminService.RejectRequest(rejectBloodRequestDTO);
                var response = new SuccessResponseModel<RejectBloodRequestReturnDTO>(200, "Request rejected successfully", result);
                return Ok(response);
            }
            catch (BloodRequestDetailsNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
