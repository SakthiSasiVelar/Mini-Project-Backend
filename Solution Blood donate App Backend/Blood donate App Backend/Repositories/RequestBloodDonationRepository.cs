using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class RequestBloodDonationRepository : RequestBloodDetailsRepository
    {
        public RequestBloodDonationRepository(BloodDonateAppDbContext dbcontext): base(dbcontext) { }
        public virtual async Task<IEnumerable<RequestBlood>> GetAll()
        {
            try
            {
                return await _dbContext.RequestDetails.Include(request => request.BloodDonations).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsListNotFoundException();
            }
        }

        public virtual async Task<RequestBlood> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.RequestDetails.Include(request => request.BloodDonations).SingleOrDefaultAsync(RequestBlood => RequestBlood.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new BloodRequestDetailsNotFoundException(id);
            }
            catch (BloodRequestDetailsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsNotGetException();
            }
        }
    }
}
