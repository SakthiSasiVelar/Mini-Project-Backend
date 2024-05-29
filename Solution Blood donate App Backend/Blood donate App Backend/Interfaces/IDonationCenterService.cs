using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IDonationCenterService
    {
        public Task<DonationCenterReturnDTO> AddDonationCenter(DonationCenterDTO donationCenterDTO);

        public Task<DonationCenterAllBloodUnitsReturnDTO> GetDonationCenterBloodUnitsById(int centerId);

        public Task<List<DonationCenterReturnDTO>> GetDonationCenterByStateAndCity(GetDonationCenterByStateAndCityDTO donationCenterByCityDTO);
    }
}
