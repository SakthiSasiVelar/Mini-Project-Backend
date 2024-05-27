using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class DonateController : ControllerBase
    {
        private readonly IDonateService _donateService;
        private const string MemberRole = "Member";

        public DonateController(IDonateService donateService)
        {
            _donateService = donateService;
        }

        [Authorize(Roles = MemberRole)]
        [HttpPost("donate/donateBlood")]
        [ProducesResponseType(typeof(DonateBloodForRequestReturnDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DonateBloodForRequestReturnDTO>> AddDonateBloodDetails([FromBody]DonateBloodForRequestDTO donateBloodForRequestDTO)
        {
            try
            {
                var result = await _donateService.DonateBlood(donateBloodForRequestDTO);
                var response = new SuccessResponseModel<DonateBloodForRequestReturnDTO>(201, "Donation Blood Details added successfully" , result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = MemberRole)]
        [HttpGet("donate/notDonateBloodList/{requestId}")]
        [ProducesResponseType(typeof(DonateBloodForRequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DonateBloodForRequestReturnDTO>>> GetNotdonateBloodList(int requestId)
        {
            try
            {
                var result = await _donateService.NotDonatedBloodDetailsList(requestId);
                var response = new SuccessResponseModel<List<DonateBloodForRequestReturnDTO>>(200, "Not Donated Blood List fetched successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = MemberRole)]
        [HttpPut("donate/approveDonation/{donationId}")]
        [ProducesResponseType(typeof(DonateBloodForApproveDonationReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DonateBloodForApproveDonationReturnDTO>> ApproveDonation(int donationId)
        {
            try
            {
                var result = await _donateService.ApproveDonation(donationId);
                var response = new SuccessResponseModel<DonateBloodForApproveDonationReturnDTO>(200, "Donation Blood Details Approved and donated successfully", result);
                return Ok(response);    
            }
            catch(BloodDonateDetailsNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(BloodRequestDetailsNotFoundException ex)
            {
                return NotFound(new ErrorModel(404 , ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500,new ErrorModel(500, ex.Message));
            }
        }
    }
}
