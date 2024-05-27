﻿using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class DonateBloodMapper
    {
        public async Task<DonateBloodForRequestReturnDTO> DonateBloodtoDonateBloodForRequestReturnDTO(DonateBlood donateBlood)
        {
            DonateBloodForRequestReturnDTO donateBloodForRequestReturnDTO = new DonateBloodForRequestReturnDTO()
            {
                DonationId = donateBlood.Id,
                RequestId = (int)donateBlood.RequestId,
                DonatedUserId = donateBlood.UserId,
                BloodType = donateBlood.BloodType,
                RhFactor = donateBlood.RhFactor,
                DonateDateTime = donateBlood.DonateDateTime,
                DonationStatus = donateBlood.DonationStatus,
                DonationType = donateBlood.DonationType,
                UnitsDonated = donateBlood.UnitsDonated,
            };
            return donateBloodForRequestReturnDTO;
        }

        public async Task<List<DonateBloodForRequestReturnDTO>> DonateBloodtoDonateBloodForRequestReturnDTOList(List<DonateBlood> donateBloodList)
        {
            List<DonateBloodForRequestReturnDTO> listOfDonateBloodForRequestReturnDTO = new List<DonateBloodForRequestReturnDTO>();
            foreach(var donateBlood in donateBloodList)
            {
                DonateBloodForRequestReturnDTO donateBloodForRequestReturnDTO = new DonateBloodForRequestReturnDTO()
                {
                    DonationId = donateBlood.Id,
                    RequestId = (int)donateBlood.RequestId,
                    DonatedUserId = donateBlood.UserId,
                    BloodType = donateBlood.BloodType,
                    RhFactor = donateBlood.RhFactor,
                    DonateDateTime = donateBlood.DonateDateTime,
                    DonationStatus = donateBlood.DonationStatus,
                    DonationType = donateBlood.DonationType,
                    UnitsDonated = donateBlood.UnitsDonated,
                };
                listOfDonateBloodForRequestReturnDTO.Add(donateBloodForRequestReturnDTO);
            }
            return listOfDonateBloodForRequestReturnDTO;
        }

        public async Task<DonateBloodForApproveDonationReturnDTO> DonateBloodtoDonateBloodForApproveDonationReturnDTO(DonateBlood donateBlood)
        {
            DonateBloodForApproveDonationReturnDTO donateBloodForApproveDonationReturnDTO = new DonateBloodForApproveDonationReturnDTO()
            {
                DonationId = donateBlood.Id,
                DonatedUserId = donateBlood.UserId,
                DonateDateTime = donateBlood.DonateDateTime,
                BloodType = donateBlood.BloodType,
                RhFactor = donateBlood.RhFactor,
                UnitsDonated = donateBlood.UnitsDonated,
                DonationType = donateBlood.DonationType,
                DonationStatus = donateBlood.DonationStatus,
                RequestId = (int)donateBlood.RequestId,
            };
            return donateBloodForApproveDonationReturnDTO;
        }
    }
}
