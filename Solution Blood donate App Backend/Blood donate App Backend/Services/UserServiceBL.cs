using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions;
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
        private readonly IRepository<int,CenterAdminRelation> _centerAdminRelationRepository;
        private readonly IRepository<int, DonationCenter> _donationCenterRepository;
        private readonly ITokenService _tokenService;

        public UserServiceBL(IRepository<int,User> userRepository , IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository , IRepository<int, DonationCenter> donationCenterRepository, ITokenService tokenService , IRepository<int, CenterAdminRelation> centerAdminRelationRepository)
        {
            _userRepository = userRepository;
            _userAuthDetailsRepository = userAuthDetailsRepository;
            _tokenService = tokenService;
            _centerAdminRelationRepository = centerAdminRelationRepository;
            _donationCenterRepository = donationCenterRepository;
        }
        public async Task<UserRegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            User newUser = null;
            UserAuthDetails newUserAuth = null;
            User addedUser = null;
            UserAuthDetails addedUserAuth = null;
            CenterAdminRelation centerAdminRelation = null;
            CenterAdminRelation addedCenterAdminRelation = null;
            try
            {
                newUser = await new UserRegisterDTOMapper().UserRegisterDTOtoUser(userRegisterDTO);
                bool isValidEmail = await IsValidEmail(newUser);
                if (isValidEmail)
                {
                    addedUser = await _userRepository.Add(newUser);
                    if(addedUser != null)
                    {
                        newUserAuth = await new UserRegisterDTOMapper().UserRegisterDTOtoUserAuthDetails(userRegisterDTO);
                        addedUserAuth = await _userAuthDetailsRepository.Add(newUserAuth);
                        if(addedUserAuth != null)
                        {
                            if (addedUser.Role == EnumClass.Roles.CenterAdmin.ToString())
                            {
                                centerAdminRelation = new CenterAdminRelation()
                                {
                                    UserId = newUser.Id,
                                    CenterId = userRegisterDTO.CenterId
                                };
                                bool isCenterIdValid = await IsCenterIdValid(centerAdminRelation.CenterId);
                                if (!isCenterIdValid) throw new DonationCenterNotavailableException(centerAdminRelation.CenterId);
                                addedCenterAdminRelation = await _centerAdminRelationRepository.Add(centerAdminRelation);
                                if (addedCenterAdminRelation == null) throw new CenterAdminRelationDetailsNotAddException(); 
                            }
                            return await new UserMapper().UsertoUserRegisterReturnDTO(addedUser);
                        }
                        throw new UserAuthDetailsNotAddException();
                       
                    }
                    throw new UserNotAddException();
                   
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
            catch (DonationCenterNotavailableException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new UserNotRegisterException();
            }
            finally
            {
                if (addedCenterAdminRelation == null && addedUser != null && addedUserAuth != null)
                {
                    await RevertUserAuthRegister(addedUserAuth.Id);
                    await RevertUserRegister(addedUser.Id);
                }
                else if (addedUser != null && addedCenterAdminRelation == null && addedUserAuth == null)
                {
                    await RevertUserRegister(addedUser.Id);
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

        public async Task<UserUpdateReturnDTO> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await new UserUpdateDTOMapper().UserUpdateDTOtoUser(userUpdateDTO);
                var updatedUser = await _userRepository.Update(user);
                return await new UserMapper().UsertoUpdateReturnDTO(updatedUser);
            }
            catch (UserNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new UserNotUpdateException();
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

        private async Task RevertCenterAdminRelationRegister(int id)
        {
            try
            {
                await _centerAdminRelationRepository.Delete(id);
            }
            catch(Exception e)
            {
                throw new CenterAdminRelationsNotDeleteException();
            }
        }

        private async Task<bool> IsCenterIdValid(int id)
        {
            try
            {
                var center = await _donationCenterRepository.GetById(id);
                return true;
            }
            catch (BloodDonationCenterNotFoundException)
            {
                return false;
            }
            catch(Exception ex)
            {
                throw new BloodDonationCenterNotGetException();
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
