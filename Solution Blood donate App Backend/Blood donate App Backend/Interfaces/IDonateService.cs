using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IDonateService
    {
        public Task<DonateBloodForRequestReturnDTO> DonateBlood(DonateBloodForRequestDTO donateBloodForRequestDTO);

        public Task<List<DonateBloodForRequestReturnDTO>> NotDonatedBloodDetailsList(int requestId);

        public Task<DonateBloodForApproveDonationReturnDTO> ApproveDonation(int donationId);
    }
}
