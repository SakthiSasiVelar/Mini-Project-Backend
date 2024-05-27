using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Services
{
    public class DonationCenterServiceBL : IDonationCenterService
    {
        private readonly IRepository<int, DonationCenter> _donationCenterRepository;

        public DonationCenterServiceBL(IRepository<int, DonationCenter> donationCenterRepository)
        {
            _donationCenterRepository = donationCenterRepository;
        }

        public async Task<DonationCenterReturnDTO> addDonationCenter(DonationCenterDTO donationCenterDTO)
        {
            try
            {
                var donationCenter = await new DonationCenterDTOMapper().DonationCenterDTOtoDonationCenter(donationCenterDTO);
                var addedDonationCenter = await _donationCenterRepository.Add(donationCenter);
                return await new DonationCenterMapper().DonationCentertoDonationCenterReturnDTO(addedDonationCenter);
            }
            catch (Exception ex)
            {
                throw new BloodDonationCenterNotAddException();
            }
        }
    }
}
