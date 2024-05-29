using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class DonationCenterController : ControllerBase
    {
        private readonly IDonationCenterService _donationCenterService;
        private const string Member = "Member";
        private const string CenterAdmin = "CenterAdmin";
        private const string Admin = "Admin";

        public DonationCenterController(IDonationCenterService donationCenterService)
        {
            _donationCenterService = donationCenterService;
        }

        [Authorize(Roles = Admin)]
        [HttpPost("donationCenter/addCenter")]
        [ProducesResponseType(typeof(SuccessResponseModel<DonationCenterReturnDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DonationCenterReturnDTO>> AddCenter([FromBody]DonationCenterDTO donationCenterDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ValidationErrorModel(400, ModelState));
                }
                var result = await _donationCenterService.AddDonationCenter(donationCenterDTO);
                var response = new SuccessResponseModel<DonationCenterReturnDTO>(201, "Donation center added successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = CenterAdmin)]
        [HttpGet("donationCenter/getAllBloodUnits/{centerId}")]
        [ProducesResponseType(typeof(SuccessResponseModel<DonationCenterAllBloodUnitsReturnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DonationCenterAllBloodUnitsReturnDTO>> GetAllBloodUnitsByCenterId(int centerId)
        {
            try
            {
                if (centerId <= 0)
                {
                    return BadRequest(new ErrorModel(400, "invalid or missing id"));
                }
                var result = await _donationCenterService.GetDonationCenterBloodUnitsById(centerId);
                var response = new SuccessResponseModel<DonationCenterAllBloodUnitsReturnDTO>(200,"Blood units details fetched successfully",result);
                return Ok(response);
            }
            catch(BloodDonationCenterNotFoundException ex)
            {
                return NotFound(new ErrorModel(404 , ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = Member)]
        [HttpGet("donationCenter/getCenterByStateAndCity/{state}/{city}")]
        [ProducesResponseType(typeof(SuccessResponseModel<List<DonationCenterReturnDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DonationCenterReturnDTO>>> GetAllCenterByStateAndCity(GetDonationCenterByStateAndCityDTO getDonationCenterByStateAndCityDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ValidationErrorModel(400, ModelState));
                }
                var result = await _donationCenterService.GetDonationCenterByStateAndCity(getDonationCenterByStateAndCityDTO);
                var response = new SuccessResponseModel<List<DonationCenterReturnDTO>>(200, "Donation center list fetched successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

    }
}
