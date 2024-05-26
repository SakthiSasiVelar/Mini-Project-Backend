using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IUserService
    {
        public Task<UserRegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO);
        public Task<LoginReturnDTO> LoginUser(LoginDTO loginDTO);
        public Task<UserUpdateReturnDTO> UpdateUser(UserUpdateDTO userUpdateDTO);
    }
}
