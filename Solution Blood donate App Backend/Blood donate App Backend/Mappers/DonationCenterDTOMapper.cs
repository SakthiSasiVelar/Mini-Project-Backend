using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class DonationCenterDTOMapper
    {
        public async Task<DonationCenter> DonationCenterDTOtoDonationCenter(DonationCenterDTO donationCenterDTO)
        {
            DonationCenter donationCenter = new DonationCenter()
            {
                Name = donationCenterDTO.Name,
                Address = donationCenterDTO.Address,
                PostalCode = donationCenterDTO.PostalCode,
                City = donationCenterDTO.City,
                State = donationCenterDTO.State,
                ContactNumber = donationCenterDTO.ContactNumber,
                OperatingHours = donationCenterDTO.OperatingHours,
            };
            return donationCenter;
        }
    }
}
