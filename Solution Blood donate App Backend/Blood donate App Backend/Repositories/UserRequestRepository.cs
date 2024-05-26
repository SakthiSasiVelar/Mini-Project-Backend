﻿using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class UserRequestRepository : UserRepository
    {
        public UserRequestRepository(BloodDonateAppDbContext dbContext) : base(dbContext) { }

        public override async Task<User> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.Users.Include(user => user.RequestHistory).SingleOrDefaultAsync(user => user.Id == id);
                if (entity != null)
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

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _dbContext.Users.Include(user => user.RequestHistory).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UsersListNotFoundException();
            }
        }

    }
}
