using Blood_donate_App_Backend.Exceptions.Users_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Controllers
{
    [Route("api")]
    public class AuthController :ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user/Register")]
        [ProducesResponseType(typeof(UserRegisterReturnDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserRegisterReturnDTO>> Register([FromBody]UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var result = await _userService.RegisterUser(userRegisterDTO);
                var response = new SuccessResponseModel<UserRegisterReturnDTO>(201 , "User created successfully", result );
                return Created($"/api/users/{result.Email}", response);
            }
            catch(EmailAlreadyTakenException ex)
            {
               
                return Conflict(new ErrorModel(409, ex.Message));
            }
            catch(Exception ex)
            {
               
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost("user/login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginReturnDTO>> Login([FromBody]LoginDTO loginDTO)
        {
            try
            {
                var result = await _userService.LoginUser(loginDTO);
                var response = new SuccessResponseModel<LoginReturnDTO>(200 , "Login successful" , result);
                return Ok(response);
            }
            catch(InvalidEmailPasswordException ex)
            {
                return Unauthorized(new ErrorModel(401 , ex.Message));
            }
            catch(AccountNotActiveException ex)
            {
                return StatusCode(403,new ErrorModel(403, ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

    }
}
