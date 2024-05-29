using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class DonationCenterMapper
    {
        public async Task<DonationCenterReturnDTO> DonationCentertoDonationCenterReturnDTO(DonationCenter donationCenter)
        {
            DonationCenterReturnDTO donationCenterReturnDTO = new DonationCenterReturnDTO()
            {
                DonationCenterId = donationCenter.Id,
                Name = donationCenter.Name,
                PostalCode = donationCenter.PostalCode,
                Address = donationCenter.Address,
                City = donationCenter.City,
                State = donationCenter.State,
                OperatingHours = donationCenter.OperatingHours,
                ContactNumber = donationCenter.ContactNumber,
            };
            return donationCenterReturnDTO;
        }

        public async Task<List<DonationCenterReturnDTO>> DonationCentertoDonationCenterReturnDTOList (List<DonationCenter> donationCenterList)
        {
            List<DonationCenterReturnDTO> result = new List<DonationCenterReturnDTO>();
            foreach(var  donationCenter in donationCenterList)
            {
                var obj = await DonationCentertoDonationCenterReturnDTO(donationCenter);
                result.Add(obj);
            }
            return result;
        }
    }
}
