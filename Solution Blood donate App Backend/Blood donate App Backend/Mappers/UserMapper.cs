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

        public async Task<UserUpdateReturnDTO> UsertoUpdateReturnDTO(User user)
        {
            UserUpdateReturnDTO updateReturnDTO = new UserUpdateReturnDTO()
            { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            return updateReturnDTO;
        }

        public async Task<ActivateAdminReturnDTO> UsertoActivateAdminReturnDTO(User user)
        {
            ActivateAdminReturnDTO activateAdminReturnDTO = new ActivateAdminReturnDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            return activateAdminReturnDTO;
        }
    }
}
