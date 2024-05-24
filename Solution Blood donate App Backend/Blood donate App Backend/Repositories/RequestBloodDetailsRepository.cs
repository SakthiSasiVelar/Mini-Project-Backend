using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.Request_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class RequestBloodDetailsRepository : IRepository<int, RequestBlood>
    {
        private readonly BloodDonateAppDbContext _dbContext;
        public RequestBloodDetailsRepository(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestBlood> Add(RequestBlood entity)
        {
            try
            {
                _dbContext.RequestDetails.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsNotAddException();
            }
        }

        public async Task<RequestBlood> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _dbContext.RequestDetails.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new BloodRequestDetailsNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsNotDeleteException();
            }
        }

        public async Task<IEnumerable<RequestBlood>> GetAll()
        {
            try
            {
                return await _dbContext.RequestDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsListNotFoundException();
            }
        }

        public async Task<RequestBlood> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.RequestDetails.SingleOrDefaultAsync(RequestBlood => RequestBlood.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new BloodRequestDetailsNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsNotGetException();
            }
        }

        public async Task<RequestBlood> Update(RequestBlood entity)
        {
            try
            {
                var RequestBlood = await GetById(entity.Id);
                if (RequestBlood != null)
                {
                    _dbContext.RequestDetails.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new BloodRequestDetailsNotFoundException(entity.Id);
            }
            catch (Exception ex)
            {
                throw new BloodRequestDetailsNotUpdateException();
            }
        }
    }
}
