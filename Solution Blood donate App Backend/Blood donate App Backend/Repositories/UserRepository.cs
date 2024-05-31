using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.Users_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        protected readonly BloodDonateAppDbContext _dbContext;
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
                _dbContext.Users.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserNotDeleteException();
            }
        }

        public virtual async Task<IEnumerable<User>> GetAll()
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


        public virtual async Task<User> GetById(int id)
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
            catch (UserNotFoundException)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new UserNotGetException();
            }
        }

        public async Task<User> Update(User entity)
        {
            try
            {
                var existingUser = await GetById(entity.Id);
                _dbContext.Entry(existingUser).State = EntityState.Detached;
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                var user = await GetById(entity.Id);
                return entity;
            }
            catch(UserNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserNotUpdateException();
            }
        }
    }
}
