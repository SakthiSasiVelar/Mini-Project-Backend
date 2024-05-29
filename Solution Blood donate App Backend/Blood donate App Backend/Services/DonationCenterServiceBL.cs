using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using Blood_donate_App_Backend.Repositories;

namespace Blood_donate_App_Backend.Services
{
    public class DonationCenterServiceBL : IDonationCenterService
    {
        private readonly IRepository<int, DonationCenter> _donationCenterRepository;
        private readonly DonationCenterInventoryRepository _donationCenterInventoryRepository;

        public DonationCenterServiceBL(IRepository<int, DonationCenter> donationCenterRepository , DonationCenterInventoryRepository donationCenterInventoryRepository)
        {
            _donationCenterRepository = donationCenterRepository;
            _donationCenterInventoryRepository = donationCenterInventoryRepository;
        }


        public async Task<DonationCenterReturnDTO> AddDonationCenter(DonationCenterDTO donationCenterDTO)
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



        public async Task<DonationCenterAllBloodUnitsReturnDTO> GetDonationCenterBloodUnitsById(int centerId)
        {
            try
            {
                var center = await _donationCenterInventoryRepository.GetById(centerId);
                var groupedBloodrecords = center.InventoryHistory
                                    .GroupBy(br => new { br.BloodType, br.RhFactor })
                                    .Select(group => new GroupedBloodRecordDTO
                                    {
                                        BloodType = group.Key.BloodType,
                                        RhFactor = group.Key.RhFactor,
                                        TotalUnits = group.Sum(br => int.Parse(br.Units))
                                    })
                                    .ToList();

                return await new GroupedBloodRecordsMapper().GroupedBloodRecordsDTOtoDonationCenterAllBloodUnitsReturnDTO(groupedBloodrecords);
            }
            catch (BloodDonationCenterNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new GetDonationCenterBloodUnitsByIdException(centerId);
            }
        }

        public async Task<List<DonationCenterReturnDTO>> GetDonationCenterByStateAndCity(GetDonationCenterByStateAndCityDTO donationCenterByCityDTO)
        {
            try
            {
                var listofAllCenters = await _donationCenterRepository.GetAll();
                var listOfCentersByCity = listofAllCenters
                        .Where(center => center.State.ToLower() == donationCenterByCityDTO.State.ToLower() && center.City.ToLower() == donationCenterByCityDTO.City.ToLower())
                        .ToList();

                return await new DonationCenterMapper().DonationCentertoDonationCenterReturnDTOList(listOfCentersByCity);
            }
            catch(Exception ex)
            {
                throw new GetDonationCenterByStateAndCityException();
            }
        }
    }
}
