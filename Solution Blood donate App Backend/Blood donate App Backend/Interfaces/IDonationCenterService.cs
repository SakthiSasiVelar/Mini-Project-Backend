using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IDonationCenterService
    {
        public Task<DonationCenterReturnDTO> addDonationCenter(DonationCenterDTO donationCenterDTO);
    }
}
