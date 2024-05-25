using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class UserMapper
    {
        public async Task<UserRegisterReturnDTO> UsertoUserRegisterReturnDTO(User user)
        {
            UserRegisterReturnDTO userRegisterReturnDTO = new UserRegisterReturnDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            return userRegisterReturnDTO;
        }
    }
}
