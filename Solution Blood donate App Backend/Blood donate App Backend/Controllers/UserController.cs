using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPut("user/updateProfile/{id}")]
        [ProducesResponseType(typeof(UserUpdateReturnDTO) , StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserUpdateReturnDTO>> Update([FromBody]UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var result = await _userService.UpdateUser(userUpdateDTO);
                var response = new SuccessResponseModel<UserUpdateReturnDTO>(200 , "User details updated successfully", result);
                return Ok(response);
            }
            catch(UserNotFoundException ex)
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
