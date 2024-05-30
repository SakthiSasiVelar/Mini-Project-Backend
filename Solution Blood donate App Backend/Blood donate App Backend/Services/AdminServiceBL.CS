using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.Admin_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
using Blood_donate_App_Backend.Exceptions.Users_Exception;
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
            catch(UserAuthDetailsNotFoundByEmailException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ActivateAdminException(id);
            }
        }

        

        public async Task<ApprovedBloodRequestReturnDTO> ApproveRequest(int id)
        {
            try
            {
                var request = await _requestBloodRepository.GetById(id);
                request.RequestApprovalStatus = EnumClass.RequestApprovalStatus.Approved.ToString();
                var updatedRequest = await _requestBloodRepository.Update(request);
                return await new RequestBloodMapper().RequestBloodtoApprovedBloodRequestReturnDTO(updatedRequest);

            }
            catch(BloodRequestDetailsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RequestApprovalException(id);
            }
        }

        public async Task<RejectBloodRequestReturnDTO> RejectRequest(RejectBloodRequestDTO rejectBloodRequestDTO)
        {
            try
            {
                var request = await _requestBloodRepository.GetById(rejectBloodRequestDTO.Id);
                request.RequestApprovalStatus = EnumClass.RequestApprovalStatus.Rejected.ToString();
                request.RejectReason = rejectBloodRequestDTO.RejectReason;
                var updatedRequest = await _requestBloodRepository.Update(request);
                return await new RequestBloodMapper().RequestBloodtoRejectBloodRequestReturnDTO(updatedRequest);

            }
            catch (BloodRequestDetailsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RequestRejectionException(rejectBloodRequestDTO.Id);
            }
        }
    }
}
