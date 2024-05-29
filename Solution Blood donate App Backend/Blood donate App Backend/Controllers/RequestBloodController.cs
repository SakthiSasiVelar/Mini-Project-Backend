using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class RequestBloodController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private const string MemberRole = "Member";
        private const string AdminRole = "Admin";

        public RequestBloodController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [Authorize(Roles = MemberRole)]
        [HttpPost("request/addRequest")]
        [ProducesResponseType(typeof(SuccessResponseModel<BloodRequestReturnDTO>) , StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BloodRequestReturnDTO>> AddRequest([FromBody]BloodRequestDTO bloodRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ValidationErrorModel(400, ModelState));
                }
                var result = await _requestService.RequestBlood(bloodRequestDTO);
                var response = new SuccessResponseModel<BloodRequestReturnDTO>(201, "Request successfully created", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = AdminRole)]
        [HttpGet("request/pendingRequest")]
        [ProducesResponseType(typeof(SuccessResponseModel<List<RequestBloodDetailsForAdminDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<RequestBloodDetailsForAdminDTO>>> GetPendingRequest()
        {
            try
            {
                var result = await _requestService.GetAllPendingRequest();
                var response = new SuccessResponseModel<List<RequestBloodDetailsForAdminDTO>>(200, "All Pending requests fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = MemberRole)]
        [HttpGet("request/approvedRequest")]
        [ProducesResponseType(typeof(SuccessResponseModel<List<BloodRequestReturnDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BloodRequestReturnDTO>>> GetApprovedRequest()
        {
            try
            {
                var result = await _requestService.GetAllApprovedRequest();
                var response = new SuccessResponseModel<List<BloodRequestReturnDTO>>(200, "All approved requests fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
