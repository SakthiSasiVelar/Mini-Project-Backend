using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IUserService
    {
        public Task<UserRegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO);
        public Task<LoginReturnDTO> LoginUser(LoginDTO loginDTO);
    }
}
