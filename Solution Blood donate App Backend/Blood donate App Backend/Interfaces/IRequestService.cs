﻿using Blood_donate_App_Backend.Models.DTOs;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface IRequestService
    {
        public Task<BloodRequestReturnDTO> RequestBlood(BloodRequestDTO bloodRequestDTO);
    }
}
