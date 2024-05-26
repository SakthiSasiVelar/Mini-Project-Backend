using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class DonationCenterRepository : IRepository<int,DonationCenter>
    {
        protected readonly BloodDonateAppDbContext _dbContext;
        public DonationCenterRepository(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DonationCenter> Add(DonationCenter entity)
        {
            try
            {
                _dbContext.DonationCenters.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new BloodDonationCenterNotAddException();
            }
        }

        public async Task<DonationCenter> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _dbContext.DonationCenters.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new BloodDonationCenterNotFoundException(id);
            }
            catch (BloodDonationCenterNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodDonationCenterNotDeleteException();
            }
        }

        public virtual async Task<IEnumerable<DonationCenter>> GetAll()
        {
            try
            {
                return await _dbContext.DonationCenters.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new BloodDonationCenterListNotFoundException();
            }
        }

        public virtual async Task<DonationCenter> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.DonationCenters.SingleOrDefaultAsync(DonationCenter => DonationCenter.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new BloodDonationCenterNotFoundException(id);
            }
            catch (BloodDonationCenterNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodDonationCenterNotGetException();
            }
        }

        public async Task<DonationCenter> Update(DonationCenter entity)
        {
            try
            {
                var DonationCenter = await GetById(entity.Id);
                if (DonationCenter != null)
                {
                    _dbContext.DonationCenters.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new BloodDonationCenterNotFoundException(entity.Id);
            }
            catch (BloodDonationCenterNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BloodDonationCenterNotUpdateException();
            }
        }
    }
}
