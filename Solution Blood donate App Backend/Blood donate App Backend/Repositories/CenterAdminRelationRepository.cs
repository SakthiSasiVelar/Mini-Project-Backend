using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class CenterAdminRelationRepository : IRepository<int,CenterAdminRelation>
    {
        private readonly BloodDonateAppDbContext _dbContext;
        public CenterAdminRelationRepository(BloodDonateAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CenterAdminRelation> Add(CenterAdminRelation entity)
        {
            try
            {
                _dbContext.CenterAdminRelations.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new CenterAdminRelationDetailsNotAddException();
            }
        }

        public async Task<CenterAdminRelation> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                _dbContext.CenterAdminRelations.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity; 
            }
            catch (CenterAdminRelationsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CenterAdminRelationsNotDeleteException();
            }
        }

        public async Task<IEnumerable<CenterAdminRelation>> GetAll()
        {
            try
            {
                return await _dbContext.CenterAdminRelations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new CenterAdminRelationsListNotFoundException();
            }
        }

        public async Task<CenterAdminRelation> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.CenterAdminRelations.SingleOrDefaultAsync(CenterAdminRelation => CenterAdminRelation.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new CenterAdminRelationsNotFoundException(id);
            }
            catch (CenterAdminRelationsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CenterAdminRelationsNotGetException();
            }
        }

        public async Task<CenterAdminRelation> Update(CenterAdminRelation entity)
        {
            try
            {
                var CenterAdminRelation = await GetById(entity.Id);
                _dbContext.Entry(CenterAdminRelation).State = EntityState.Detached;
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (CenterAdminRelationsNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CenterAdminRelationsNotUpdateException();
            }
        }
    }
}
