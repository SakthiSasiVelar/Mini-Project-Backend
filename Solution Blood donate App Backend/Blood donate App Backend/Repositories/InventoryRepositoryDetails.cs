using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Exceptions.Inventory_Exceptions;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class InventoryRepositoryDetails : IRepository<int,Inventory>
    {
        private readonly BloodDonateAppDbContext _dbContext;
        public InventoryRepositoryDetails(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Inventory> Add(Inventory entity)
        {
            try
            {
                _dbContext.Inventory.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new InventoryNotAddException();
            }
        }

        public async Task<Inventory> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _dbContext.Inventory.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new InventoryNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new InventoryNotDeleteException();
            }
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            try
            {
                return await _dbContext.Inventory.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InventoryListNotFoundException();
            }
        }

        public async Task<Inventory> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.Inventory.SingleOrDefaultAsync(Inventory => Inventory.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new InventoryNotFoundException(id);
            }
            catch (Exception ex)
            {
                throw new InventoryNotGetException();
            }
        }

        public async Task<Inventory> Update(Inventory entity)
        {
            try
            {
                var Inventory = await GetById(entity.Id);
                if (Inventory != null)
                {
                    _dbContext.Inventory.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                throw new InventoryNotFoundException(entity.Id);
            }
            catch (Exception ex)
            {
                throw new InventoryNotUpdateException();
            }
        }
    }
}
