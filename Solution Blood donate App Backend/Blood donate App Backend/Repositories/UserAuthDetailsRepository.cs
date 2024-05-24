using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class UserAuthDetailsAuthDetailsRepository : IRepository<int,UserAuthDetails>
    {
        private readonly BloodDonateAppDbContext _dbContext;
        public UserAuthDetailsAuthDetailsRepository(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAuthDetails> Add(UserAuthDetails entity) 
        {
            try
            {
                _dbContext.UsersAuthDetails.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotAddException();
            }
        }

        public async Task<UserAuthDetails> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _dbContext.UsersAuthDetails.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new UserAuthDetailsNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotDeleteException();
            }
        }

        public async Task<IEnumerable<UserAuthDetails>> GetAll()
        {
            try
            {
                return await _dbContext.UsersAuthDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsListNotFoundException();
            }
        }

        public async Task<UserAuthDetails> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.UsersAuthDetails.SingleOrDefaultAsync(UserAuthDetails => UserAuthDetails.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new UserAuthDetailsNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotGetException();
            }
        }

        public async Task<UserAuthDetails> Update(UserAuthDetails entity)
        {
            try
            {
                var UserAuthDetails = await GetById(entity.Id);
                if (UserAuthDetails != null)
                {
                    _dbContext.UsersAuthDetails.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new UserAuthDetailsNotFoundException(entity.Id);
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotUpdateException();
            }
        }
    }
}
