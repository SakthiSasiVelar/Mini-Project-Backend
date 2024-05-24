using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly BloodDonateAppDbContext _dbContext;
        public UserRepository(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Add(User entity)
        {
            try
            {
                _dbContext.Users.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new UserNotAddException();
            }
        }

        public async Task<User> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if(entity != null)
                {
                    _dbContext.Users.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new UserNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new UserNotDeleteException();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UsersListNotFoundException();
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);
                if( entity != null)
                {
                    return entity;
                }
                throw new UserNotFoundException(id);
            }
            catch(Exception ex)
            {
                throw new UserNotGetException();
            }
        }

        public async Task<User> Update(User entity)
        {
            try
            {
                var user = await GetById(entity.Id);
                if(user != null)
                {
                    _dbContext.Users.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new UserNotFoundException(entity.Id);
            }
            catch(Exception ex)
            {
                throw new UserNotUpdateException();
            }
        }
    }
}
