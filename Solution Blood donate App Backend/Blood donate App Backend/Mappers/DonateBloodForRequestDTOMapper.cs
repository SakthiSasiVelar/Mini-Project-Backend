using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class DonateBloodForRequestDTOMapper
    {
        public async Task<DonateBlood> DonateBloodForRequestDTOtoDonateBlood(DonateBloodForRequestDTO donateBloodForRequestDTO)
        {
            DonateBlood donateBlood = new DonateBlood()
            {
                UserId = donateBloodForRequestDTO.UserId,
                DonationType = EnumClass.DonationType.Requester.ToString(),
                RequestId = donateBloodForRequestDTO.RequestId,
                UnitsDonated = donateBloodForRequestDTO.UnitsDonated,
                DonateDateTime = donateBloodForRequestDTO.DonateDateTime,
                DonationStatus = EnumClass.DonationStatus.NotDonated.ToString(),
                BloodType = donateBloodForRequestDTO.BloodType,
                RhFactor = donateBloodForRequestDTO.RhFactor,
            };
            return donateBlood;
        }
    }
}
