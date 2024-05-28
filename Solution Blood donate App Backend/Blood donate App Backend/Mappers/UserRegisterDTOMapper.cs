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
                ContactNumber = userRegisterDTO.ContactNumber,
                PostalCode = userRegisterDTO.PostalCode,
            };
            var role = userRegisterDTO.Role.ToLower();
            if(role == "member") user.Role = EnumClass.Roles.Member.ToString();
            else if(role == "center admin") user.Role = EnumClass.Roles.CenterAdmin.ToString();
            else if(role == "admin")user.Role = EnumClass.Roles.Admin.ToString();
            return user;
        }

        public async Task<UserAuthDetails> UserRegisterDTOtoUserAuthDetails(UserRegisterDTO userRegisterDTO)
        {
            UserAuthDetails userAuthDetails = new UserAuthDetails();
            HMACSHA512 hMACSHA = new HMACSHA512();
            userAuthDetails.Email = userRegisterDTO.Email;
            userAuthDetails.PasswordHashKey = hMACSHA.Key;
            userAuthDetails.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password));
            if(userRegisterDTO.Role == "Member") userAuthDetails.IsActive = true;
            else userAuthDetails.IsActive = false;
            var role = userRegisterDTO.Role.ToLower();
            if (role == "member") userAuthDetails.Role = EnumClass.Roles.Member.ToString();
            else if (role == "center admin") userAuthDetails.Role = EnumClass.Roles.CenterAdmin.ToString();
            else if (role == "admin") userAuthDetails.Role = EnumClass.Roles.Admin.ToString();
            return userAuthDetails;
        }
    }
}
