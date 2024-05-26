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

        public RequestBloodController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [Authorize(Roles = MemberRole)]
        [HttpPost("request/addRequest")]
        [ProducesResponseType(typeof(BloodRequestReturnDTO) , StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BloodRequestReturnDTO>> AddRequest([FromBody]BloodRequestDTO bloodRequestDTO)
        {
            try
            {
                var result = await _requestService.RequestBlood(bloodRequestDTO);
                var response = new SuccessResponseModel<BloodRequestReturnDTO>(201, "Request successfully created", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(500,ex.Message));
            }
        }
    }
}
