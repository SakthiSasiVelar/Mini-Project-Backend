using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using Blood_donate_App_Backend.Repositories;

namespace Blood_donate_App_Backend.Services
{
    public class DonateServiceBL : IDonateService
    {
        private readonly IRepository<int, DonateBlood> _donateRepository;
        private readonly IRepository<int, RequestBlood> _requestBloodRepository;
        private readonly RequestBloodDonationRepository _requestBloodDonationRepository;

        public DonateServiceBL(IRepository<int, DonateBlood> donateRepository , IRepository<int, RequestBlood> requestBloodRepository, RequestBloodDonationRepository requestBloodDonationRepository)
        {
            _donateRepository = donateRepository;
            _requestBloodRepository = requestBloodRepository;
            _requestBloodDonationRepository = requestBloodDonationRepository;
        }

        public async Task<DonateBloodForApproveDonationReturnDTO> ApproveDonation(int donationId)
        {
            try
            {
                var donateBloodDetails = await _donateRepository.GetById(donationId);
                donateBloodDetails.DonationStatus = EnumClass.DonationStatus.Donated.ToString();
                var updatedDonateBloodDetails = await _donateRepository.Update(donateBloodDetails);
                var request = await _requestBloodRepository.GetById((int)updatedDonateBloodDetails.RequestId);
                int unitsCollected = int.Parse(request.UnitsCollected);
                int currentDonatedUnits = int.Parse(updatedDonateBloodDetails.UnitsDonated);
                int totalUnits = unitsCollected + currentDonatedUnits;
                request.UnitsCollected = totalUnits.ToString();
                int unitsNeeded = int.Parse(request.UnitsNeeded);
                if (totalUnits >= unitsNeeded)
                {
                    request.FulfillmentStatus = EnumClass.FulFillmentStatus.Fulfilled.ToString();
                }
                else
                {
                    request.FulfillmentStatus = EnumClass.FulFillmentStatus.PartiallyFulfilled.ToString();
                }
                var updatedRequest = await _requestBloodRepository.Update(request);
                return await new DonateBloodMapper().DonateBloodtoDonateBloodForApproveDonationReturnDTO(updatedDonateBloodDetails);
            }
            catch(BloodDonateDetailsNotFoundException)
            {
                throw;
            }
            catch (BloodRequestDetailsNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ApproveDonationException(donationId);
            }
        }

        public async Task<DonateBloodForRequestReturnDTO> DonateBlood(DonateBloodForRequestDTO donateBloodForRequestDTO)
        {
            try
            {
                var donateBloodDetails = await new DonateBloodForRequestDTOMapper().DonateBloodForRequestDTOtoDonateBlood(donateBloodForRequestDTO);
                var addedDonateBloodDetails = await _donateRepository.Add(donateBloodDetails);
                return await new DonateBloodMapper().DonateBloodtoDonateBloodForRequestReturnDTO(addedDonateBloodDetails);
            }
            catch (Exception ex)
            {
                throw new BloodDonateDetailsNotAddException();
            }
        }

        public async Task<List<DonateBloodForRequestReturnDTO>> NotDonatedBloodDetailsList(int requestId)
        {
            try
            {
                var request = await _requestBloodDonationRepository.GetById(requestId);
                List<DonateBlood> notDonateBloodList = new List<DonateBlood>();
                string notDonated = EnumClass.DonationStatus.NotDonated.ToString();
                foreach(var donateBloodDetails in request.BloodDonations)
                {
                    if (donateBloodDetails.DonationStatus == notDonated) notDonateBloodList.Add(donateBloodDetails);
                }
                return await new DonateBloodMapper().DonateBloodtoDonateBloodForRequestReturnDTOList(notDonateBloodList);

            }
            catch(Exception ex)
            {
                throw new NotDonatedBloodListGetException(requestId);
            }
        }
    }
}
