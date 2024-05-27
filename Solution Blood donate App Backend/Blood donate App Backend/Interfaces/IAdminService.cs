using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IAdminService
    {
        public Task<ActivateAdminReturnDTO> ActivateAdmin(int id);

       

        public Task<ApprovedBloodRequestReturnDTO> ApproveRequest(int id);

        public Task<RejectBloodRequestReturnDTO> RejectRequest(RejectBloodRequestDTO rejectBloodRequestDTO);
    }
}
