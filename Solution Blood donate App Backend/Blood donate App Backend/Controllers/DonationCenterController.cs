using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class DonationCenterController : ControllerBase
    {
        private readonly IDonationCenterService _donationCenterService;

        public DonationCenterController(IDonationCenterService donationCenterService)
        {
            _donationCenterService = donationCenterService;
        }

        [HttpPost("donationCenter/addCenter")]
        [ProducesResponseType(typeof(DonationCenterReturnDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DonationCenterReturnDTO>> addCenter([FromBody]DonationCenterDTO donationCenterDTO)
        {
            try
            {
                var result = await _donationCenterService.addDonationCenter(donationCenterDTO);
                var response = new SuccessResponseModel<DonationCenterReturnDTO>(201, "Donation center added successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
