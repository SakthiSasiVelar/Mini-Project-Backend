using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class GroupedBloodRecordsMapper
    {
        public async Task<DonationCenterAllBloodUnitsReturnDTO> GroupedBloodRecordsDTOtoDonationCenterAllBloodUnitsReturnDTO(List<GroupedBloodRecordDTO> groupedBloodRecordDTO)
        {
            DonationCenterAllBloodUnitsReturnDTO result = new DonationCenterAllBloodUnitsReturnDTO();
            foreach (var groupedResult in groupedBloodRecordDTO)
            {
                if (groupedResult.BloodType == "A" && groupedResult.RhFactor == "positive")
                {
                    result.APositive = groupedResult.TotalUnits;
                }
                else if (groupedResult.BloodType == "A" && groupedResult.RhFactor == "negative")
                {
                    result.ANegative = groupedResult.TotalUnits;
                }
                else if (groupedResult.BloodType == "B" && groupedResult.RhFactor == "positive")
                {
                    result.BPositive = groupedResult.TotalUnits;
                }
                else if(groupedResult.BloodType == "B" && groupedResult.RhFactor == "negative")
                {
                    result.BNegative = groupedResult.TotalUnits ;
                }
                else if(groupedResult.BloodType == "O" && groupedResult.RhFactor == "positive")
                {
                    result.OPositive = groupedResult.TotalUnits ;
                }
                else  if(groupedResult.BloodType == "0" && groupedResult.RhFactor == "negative")
                {
                    result.ONegative = groupedResult.TotalUnits ;
                }
                else if(groupedResult.BloodType == "AB" && groupedResult.RhFactor == "positive")
                {
                    result.ABPositive = groupedResult.TotalUnits;
                }
                else if(groupedResult.BloodType == "AB" && groupedResult.RhFactor == "negative")
                {
                    result.ABNegative = groupedResult.TotalUnits ;
                }
                
            }
            return result;
        }
    }
}
