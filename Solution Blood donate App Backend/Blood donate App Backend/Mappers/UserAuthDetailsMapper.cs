using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class UserAuthDetailsMapper
    {
        public async Task<LoginReturnDTO> UserAuthDetailstoLoginReturnDTO(UserAuthDetails userAuthDetails , string token)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO()
            {
                Email = userAuthDetails.Email,
                Role = userAuthDetails.Role,
                Token = token
            };
            return loginReturnDTO;
        }
    }
}
