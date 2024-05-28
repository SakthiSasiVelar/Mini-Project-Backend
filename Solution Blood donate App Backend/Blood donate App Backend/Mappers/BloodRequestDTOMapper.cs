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
                PatientName = bloodRequestDTO.PatientName,
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

            var BloodType = bloodRequestDTO.BloodType.ToLower();
            if(BloodType == "a") request.BloodType = EnumClass.BloodType.A.ToString();
            else if(BloodType == "b") request.BloodType = EnumClass.BloodType.B.ToString();
            else if(BloodType == "ab") request.BloodType = EnumClass.BloodType.AB.ToString();
            else if(BloodType == "o")request.BloodType = EnumClass.BloodType.O.ToString();

            var RhFactor = bloodRequestDTO.RhFactor.ToLower();
            if(RhFactor == "positive") request.RhFactor = EnumClass.RhFactor.positive.ToString();
            else if(RhFactor == "negative") request.RhFactor = EnumClass.RhFactor.negative.ToString();

            return request;
        }
    }
}
