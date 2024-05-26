using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using static Blood_donate_App_Backend.Models.DTOs.EnumClass;

namespace Blood_donate_App_Backend.Mappers
{
    public class RequestBloodMapper
    {
        public async Task<BloodRequestReturnDTO> RequestBloodtoBloodRequestReturnDTO(RequestBlood requestBlood)
        {
            BloodRequestReturnDTO bloodRequestReturnDTO = new BloodRequestReturnDTO()
            {
                RequestId = requestBlood.Id,
                RequestedById = requestBlood.UserId,
                PatientName = requestBlood.PatientName,
                BloodType = requestBlood.BloodType,
                RhFactor = requestBlood.RhFactor,
                UnitsCollected = requestBlood.UnitsCollected,
                UnitsNeeded = requestBlood.UnitsNeeded,
                RequestApprovalStatus = requestBlood.RequestApprovalStatus,
                HospitalName = requestBlood.HospitalName,
                HospitalAddress = requestBlood.HospitalAddress,
                DoctorName = requestBlood.DoctorName,
                DoctorContactNumber = requestBlood.DoctorContactNumber,
                Description = requestBlood.Description,
                RequestedContactNumber = requestBlood.RequestedContactNumber,
                RequestedDateTime = requestBlood.RequestedDateTime,
                FulfillmentStatus = requestBlood.FulfillmentStatus,
            };
            var urgency = requestBlood.Urgency;
            if (urgency == EnumClass.Urgency.Immediate.ToString())
            {
                bloodRequestReturnDTO.Urgency = "Immediate";
            }
            else if (urgency == EnumClass.Urgency.WithinAWeek.ToString())
            {
                bloodRequestReturnDTO.Urgency = "Within a week";
            }
            return bloodRequestReturnDTO;
        }

        public async Task<List<RequestBloodDetailsForAdminDTO>> RequestBloodtoRequestBloodDetailsForAdminDTO(List<RequestBlood> requestBloodList)
        {
            List<RequestBloodDetailsForAdminDTO> listOfRequestBloodDetailsForAdminDTO = new List<RequestBloodDetailsForAdminDTO>();
            foreach(var requestBlood in requestBloodList)
            {
                RequestBloodDetailsForAdminDTO requestBloodDetailsForAdminDTO = new RequestBloodDetailsForAdminDTO()
                {
                    RequestId = requestBlood.Id,
                    RequestedUserId = requestBlood.UserId,
                    PatientName = requestBlood.PatientName,
                    BloodType = requestBlood.BloodType,
                    RhFactor = requestBlood.RhFactor,
                    UnitsCollected = requestBlood.UnitsCollected,
                    UnitsNeeded = requestBlood.UnitsNeeded,
                    RequestApprovalStatus = requestBlood.RequestApprovalStatus,
                    HospitalName = requestBlood.HospitalName,
                    HospitalAddress = requestBlood.HospitalAddress,
                    DoctorName = requestBlood.DoctorName,
                    DoctorContactNumber = requestBlood.DoctorContactNumber,
                    Description = requestBlood.Description,
                    RequestedContactNumber = requestBlood.RequestedContactNumber,
                    RequestedDateTime = requestBlood.RequestedDateTime,
                    FulfillmentStatus = requestBlood.FulfillmentStatus,

                };
                var urgency = requestBlood.Urgency;
                if (urgency == EnumClass.Urgency.Immediate.ToString())
                {
                    requestBloodDetailsForAdminDTO.Urgency = "Immediate";
                }
                else if (urgency == EnumClass.Urgency.WithinAWeek.ToString())
                {
                    requestBloodDetailsForAdminDTO.Urgency = "Within a week";
                }
                listOfRequestBloodDetailsForAdminDTO.Add(requestBloodDetailsForAdminDTO);
            }
           
            return listOfRequestBloodDetailsForAdminDTO;
        }
    }
}
