using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class DonateBloodForCenterDTOMapper
    {
        public async Task<DonateBlood> DonateBloodForCenterDTOtoDonateBlood(DonateBloodForCenterDTO donateBloodForCenterDTO)
        {
            DonateBlood donateBlood = new DonateBlood()
            {
                UserId = donateBloodForCenterDTO.UserId,
                DonateDateTime = donateBloodForCenterDTO.DonateDateTime,
                UnitsDonated = donateBloodForCenterDTO.UnitsDonated,
                DonationStatus = EnumClass.DonationStatus.NotDonated.ToString(),
                DonationType = EnumClass.DonationType.Center.ToString(),
                CenterId = donateBloodForCenterDTO.CenterId
            };
            var BloodType = donateBloodForCenterDTO.BloodType.ToLower();
            if (BloodType == "a") donateBlood.BloodType = EnumClass.BloodType.A.ToString();
            else if (BloodType == "b") donateBlood.BloodType = EnumClass.BloodType.B.ToString();
            else if (BloodType == "ab") donateBlood.BloodType = EnumClass.BloodType.AB.ToString();
            else if (BloodType == "o") donateBlood.BloodType = EnumClass.BloodType.O.ToString();

            var RhFactor = donateBloodForCenterDTO.RhFactor.ToLower();
            if (RhFactor == "positive") donateBlood.RhFactor = EnumClass.RhFactor.positive.ToString();
            else if (RhFactor == "negative") donateBlood.RhFactor = EnumClass.RhFactor.negative.ToString();
            return donateBlood;
        }
    }
}
