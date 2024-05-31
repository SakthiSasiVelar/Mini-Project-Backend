using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class DonateBloodDetailsRepository : IRepository<int,DonateBlood>
    {
        private readonly BloodDonateAppDbContext _dbContext;
        public DonateBloodDetailsRepository(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DonateBlood> Add(DonateBlood entity)
        {
            try
            {
                _dbContext.DonateDetails.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new BloodDonateDetailsNotAddException();
            }
        }

        public async Task<DonateBlood> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                _dbContext.DonateDetails.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity; 
            }
            catch (BloodDonateDetailsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodDonateDetailsNotDeleteException();
            }
        }

        public async Task<IEnumerable<DonateBlood>> GetAll()
        {
            try
            {
                return await _dbContext.DonateDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new BloodDonateDetailsListNotFoundException();
            }
        }

        public async Task<DonateBlood> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.DonateDetails.SingleOrDefaultAsync(DonateBlood => DonateBlood.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new BloodDonateDetailsNotFoundException(id);
            }
            catch (BloodDonateDetailsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodDonateDetailsNotGetException();
            }
        }

        public async Task<DonateBlood> Update(DonateBlood entity)
        {
            try
            {
                var DonateBlood = await GetById(entity.Id); 
                _dbContext.DonateDetails.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity; 
            }
            catch (BloodDonateDetailsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodDonateNotUpdateException();
            }
        }
    }
}
