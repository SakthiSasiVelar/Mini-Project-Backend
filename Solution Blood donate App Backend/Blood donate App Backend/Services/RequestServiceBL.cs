using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.Request_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Services
{
    public class RequestServiceBL : IRequestService
    {
        private readonly IRepository<int, RequestBlood> _bloodRequestRepository;

        public RequestServiceBL(IRepository<int, RequestBlood> bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }

        public async Task<BloodRequestReturnDTO> RequestBlood(BloodRequestDTO bloodRequestDTO)
        {
            try
            {
                var request = await new BloodRequestDTOMapper().BloodRequestDTOtoRequestBlood(bloodRequestDTO);
                var addedRequest = await _bloodRequestRepository.Add(request);
                return await new RequestBloodMapper().RequestBloodtoBloodRequestReturnDTO(request); 
            }
            catch(Exception ex)
            {
                throw new BloodRequestDetailsNotAddException();
            }
        }

        public async Task<List<RequestBloodDetailsForAdminDTO>> GetAllPendingRequest()
        {
            try
            {
                var listOfRequests = await _bloodRequestRepository.GetAll();
                List<RequestBlood> pendingRequestList = new List<RequestBlood>();
                string approvalStatus = EnumClass.RequestApprovalStatus.Pending.ToString();
                foreach (var request in listOfRequests)
                {
                    if (request.RequestApprovalStatus == approvalStatus) pendingRequestList.Add(request);
                }
                return await new RequestBloodMapper().RequestBloodtoRequestBloodDetailsForAdminDTO(pendingRequestList);
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsListNotFoundException();
            }
        }

        public async Task<List<BloodRequestReturnDTO>> GetAllApprovedRequest()
        {
            try
            {
                var listOfRequests = await _bloodRequestRepository.GetAll();
                List<RequestBlood> approvedRequestList = new List<RequestBlood>();
                string approvalStatus = EnumClass.RequestApprovalStatus.Approved.ToString();
                foreach (var request in listOfRequests)
                {
                    if (request.RequestApprovalStatus == approvalStatus) approvedRequestList.Add(request);
                }
                return await new RequestBloodMapper().RequestBloodtoBloodRequestReturnListDTO(approvedRequestList);
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsListNotFoundException();
            }
        }
    }
}
