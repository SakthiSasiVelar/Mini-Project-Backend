using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IDonateService
    {
        public Task<DonateBloodForRequestReturnDTO> DonateBloodToRequester(DonateBloodForRequestDTO donateBloodForRequestDTO);

        public Task<DonateBloodForCenterReturnDTO> DonateBloodToCenter(DonateBloodForCenterDTO donateBloodForCenterDTO);

        public Task<List<DonateBloodForRequestReturnDTO>> NotDonatedBloodDetailsListForRequester(int requestId);

        public Task<List<DonateBloodForCenterReturnDTO>> NotDonatedBloodDetailsListForCenter(int centerId);

        public Task<DonateBloodForApproveDonationReturnDTO> ApproveDonationByRequester(int donationId);

        public Task<DonateBloodForApproveDonationByCenterReturnDTO> ApproveDonationByCenter(int donationId);
    }
}
