using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
using Blood_donate_App_Backend.Exceptions.Users_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace Blood_donate_App_Backend.Services
{
    public class UserServiceBL : IUserService
    {
        private readonly IRepository<int, User> _userRepository;
        private readonly IUserAuthDetailsRepository<int,UserAuthDetails> _userAuthDetailsRepository;
        private readonly ITokenService _tokenService;

        public UserServiceBL(IRepository<int,User> userRepository , IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository , ITokenService tokenService)
        {
            _userRepository = userRepository;
            _userAuthDetailsRepository = userAuthDetailsRepository;
            _tokenService = tokenService;
        }
        public async Task<UserRegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            User newUser = null;
            UserAuthDetails newUserAuth = null;
            User addedUser = null;
            UserAuthDetails addedUserAuth = null;
            try
            {
                newUser = await new UserRegisterDTOMapper().UserRegisterDTOtoUser(userRegisterDTO);
                bool isValidEmail = await IsValidEmail(newUser);
                if (isValidEmail)
                {
                    addedUser = await _userRepository.Add(newUser);
                    newUserAuth = await new UserRegisterDTOMapper().UserRegisterDTOtoUserAuthDetails(userRegisterDTO);
                    addedUserAuth = await _userAuthDetailsRepository.Add(newUserAuth);
                    return await new UserMapper().UsertoUserRegisterReturnDTO(addedUser);
                }
                else
                {
                    throw new EmailAlreadyTakenException();
                }
               
            }
            catch (EmailAlreadyTakenException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new UserNotRegisterException();
            }
            finally
            {
                if(addedUser != null && addedUserAuth == null)
                {
                    await RevertUserRegister(addedUser.Id);
                }
                else if(addedUser == null && addedUserAuth != null)
                {
                    await RevertUserAuthRegister(addedUserAuth.Id);
                }
            }
        }

        public async Task<LoginReturnDTO> LoginUser(LoginDTO loginDTO)
        {
            try
            {
                var userAuthDetails = await _userAuthDetailsRepository.GetByEmail(loginDTO.Email);
                bool isValidPassword = await IsValidPassword(userAuthDetails, loginDTO.Password);
                if(isValidPassword)
                {
                    if(userAuthDetails.IsActive)
                    {
                        var token = await _tokenService.GenerateToken(userAuthDetails);
                        return await new UserAuthDetailsMapper().UserAuthDetailstoLoginReturnDTO(userAuthDetails, token);
                    }
                    throw new AccountNotActiveException();
                }
                throw new InvalidEmailPasswordException();
            }
            catch(UserAuthDetailsNotFoundByEmailException ex)
            {
                throw new InvalidEmailPasswordException();
            }
            catch (InvalidEmailPasswordException)
            {
                throw;
            }
            catch (AccountNotActiveException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new UserNotLoginExpection();
            }

        }

        private async Task<bool> IsValidEmail(User newUser)
        {
            try
            {
                var listOfUsers = await _userRepository.GetAll();
                foreach(var user in listOfUsers)
                {
                    if (user.Email == newUser.Email) return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new UsersListNotFoundException();
            }
        }

        private async Task RevertUserRegister(int id)
        {
            try
            {
                await _userRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw new UserNotDeleteException();
            }
        }

        private async Task RevertUserAuthRegister(int id)
        {
            try
            {
                await _userAuthDetailsRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotDeleteException();
            }
        }

       private async Task<bool> IsValidPassword(UserAuthDetails userAuthDetails , string password)
       {
            HMACSHA512 hMACSHA512 = new HMACSHA512(userAuthDetails.PasswordHashKey);
            var encryptPassword = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (encryptPassword.Length != userAuthDetails.Password.Length) return false;
            for(int i=0; i<encryptPassword.Length; i++)
            {
                if (encryptPassword[i] != userAuthDetails.Password[i]) return false;
            }
            return true;
       }
    }
}
