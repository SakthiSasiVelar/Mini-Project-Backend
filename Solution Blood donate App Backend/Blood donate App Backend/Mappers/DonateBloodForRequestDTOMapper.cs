﻿using Blood_donate_App_Backend.Models;
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
            };
            var BloodType = donateBloodForRequestDTO.BloodType.ToLower();
            if (BloodType == "a") donateBlood.BloodType = EnumClass.BloodType.A.ToString();
            else if (BloodType == "b") donateBlood.BloodType = EnumClass.BloodType.B.ToString();
            else if (BloodType == "ab") donateBlood.BloodType = EnumClass.BloodType.AB.ToString();
            else if (BloodType == "o") donateBlood.BloodType = EnumClass.BloodType.O.ToString();

            var RhFactor = donateBloodForRequestDTO.RhFactor.ToLower();
            if (RhFactor == "positive") donateBlood.RhFactor = EnumClass.RhFactor.positive.ToString();
            else if (RhFactor == "negative") donateBlood.RhFactor = EnumClass.RhFactor.negative.ToString();
            return donateBlood;
        }
    }
}
