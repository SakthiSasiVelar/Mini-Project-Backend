using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace Blood_donate_App_Backend.Mappers
{
    public class UserRegisterDTOMapper
    {
        public async Task<User> UserRegisterDTOtoUser(UserRegisterDTO userRegisterDTO)
        {
            User user = new User()
            {
                Name = userRegisterDTO.Name,
                Email = userRegisterDTO.Email,
                Gender = userRegisterDTO.Gender,
                DateOfBirth = userRegisterDTO.DateOfBirth,
                City = userRegisterDTO.City,
                State = userRegisterDTO.State,
                Address = userRegisterDTO.Address,
                Role = userRegisterDTO.Role,
                ContactNumber = userRegisterDTO.ContactNumber,
                PostalCode = userRegisterDTO.PostalCode,
            };
            return user;
        }

        public async Task<UserAuthDetails> UserRegisterDTOtoUserAuthDetails(UserRegisterDTO userRegisterDTO)
        {
            UserAuthDetails userAuthDetails = new UserAuthDetails();
            HMACSHA512 hMACSHA = new HMACSHA512();
            userAuthDetails.Email = userRegisterDTO.Email;
            userAuthDetails.Role = userRegisterDTO.Role;
            userAuthDetails.PasswordHashKey = hMACSHA.Key;
            userAuthDetails.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password));
            if(userRegisterDTO.Role == "Member") userAuthDetails.IsActive = true;
            else userAuthDetails.IsActive = false;
            return userAuthDetails;
        }
    }
}
