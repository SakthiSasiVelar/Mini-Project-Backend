using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class UserUpdateDTOMapper
    {
        public async Task<User> UserUpdateDTOtoUser(UserUpdateDTO userUpdateDTO)
        {
            User user = new User();
            user.Id = userUpdateDTO.Id;
            user.Name = userUpdateDTO.Name;
            user.Address = userUpdateDTO.Address;
            user.Gender = userUpdateDTO.Gender;
            user.City = userUpdateDTO.City;
            user.PostalCode = userUpdateDTO.PostalCode;
            user.State = userUpdateDTO.State;
            user.ContactNumber = userUpdateDTO.ContactNumber;
            user.DateOfBirth = userUpdateDTO.DateOfBirth;
            return user;
        } 
    }
}
