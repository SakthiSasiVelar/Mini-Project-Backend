using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.Admin_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Mappers;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Services
{
    public class AdminServiceBL : IAdminService
    {
        private readonly IRepository<int, User> _userRepository;
        private readonly IRepository<int, RequestBlood> _requestBloodRepository;
        private readonly IUserAuthDetailsRepository<int, UserAuthDetails> _userAuthDetailsRepository;

        public AdminServiceBL(IRepository<int, User> userRepository, IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository , IRepository<int, RequestBlood> requestBloodRepository )
        {
            _userRepository = userRepository;
            _userAuthDetailsRepository = userAuthDetailsRepository;
            _requestBloodRepository = requestBloodRepository;
        }

        public async Task<ActivateAdminReturnDTO> ActivateAdmin(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                var userAuthDetails = await _userAuthDetailsRepository.GetByEmail(user.Email);
                userAuthDetails.IsActive = true;
                var updatedUserAuthDetails = await _userAuthDetailsRepository.Update(userAuthDetails);
                return await new UserMapper().UsertoActivateAdminReturnDTO(user);
            }
            catch (UserNotFoundException)
            {
                throw;
            }
            catch(UserAuthDetailsListNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ActivateAdminException(id);
            }
        }

        public async Task<List<RequestBloodDetailsForAdminDTO>> GetAllPendingRequest()
        {
            try
            {
                var listOfRequests = await _requestBloodRepository.GetAll();
                List<RequestBlood> pendingRequestList = new List<RequestBlood>();
                string approvalStatus = EnumClass.RequestApprovalStatus.Pending.ToString();
                foreach (var request in listOfRequests)
                {
                    if (request.RequestApprovalStatus == approvalStatus) pendingRequestList.Add(request);
                }
                return await new RequestBloodMapper().RequestBloodtoRequestBloodDetailsForAdminDTO(pendingRequestList);
            }
            catch(Exception ex)
            {
                throw new BloodRequestDetailsListNotFoundException();
            }
        }
    }
}
