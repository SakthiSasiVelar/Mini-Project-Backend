using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Mappers
{
    public class BloodRequestDTOMapper
    {
        public async Task<RequestBlood> BloodRequestDTOtoRequestBlood(BloodRequestDTO bloodRequestDTO)
        {
            RequestBlood request = new RequestBlood()
            {
                UserId = bloodRequestDTO.UserId,
                BloodType = bloodRequestDTO.BloodType,
                PatientName = bloodRequestDTO.PatientName,
                RhFactor = bloodRequestDTO.RhFactor,
                UnitsNeeded = bloodRequestDTO.UnitsNeeded,
                RequestedDateTime = bloodRequestDTO.RequestedDateTime,
                DoctorName = bloodRequestDTO.DoctorName,
                DoctorContactNumber = bloodRequestDTO.DoctorContactNumber,
                HospitalName = bloodRequestDTO.HospitalName,
                HospitalAddress = bloodRequestDTO.HospitalAddress,
                Description = bloodRequestDTO.Description,
                RequestedContactNumber = bloodRequestDTO.RequestedContactNumber,
                UnitsCollected = "0",
                RequestApprovalStatus = EnumClass.RequestApprovalStatus.Pending.ToString(),
                FulfillmentStatus = EnumClass.FulFillmentStatus.NotFulfilled.ToString(),

            };
            var urgency = bloodRequestDTO.Urgency.ToLower();
            if (urgency == "immediate" ) {
                request.Urgency = EnumClass.Urgency.Immediate.ToString();
            }
            else if(urgency == "within a week")
            {
                request.Urgency = EnumClass.Urgency.WithinAWeek.ToString();
            }
            return request;
        }
    }
}
