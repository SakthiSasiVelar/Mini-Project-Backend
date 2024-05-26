using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Repositories
{
    public class DonationCenterBloodDonationRepository : DonationCenterRepository
    {
        public DonationCenterBloodDonationRepository(BloodDonateAppDbContext context) : base(context) { }
        public override async Task<IEnumerable<DonationCenter>> GetAll()
        {
            try
            {
                return await _dbContext.DonationCenters.Include(donationCenter => donationCenter.BloodDonations).ToListAsync();
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
                var entity = await _dbContext.DonationCenters.Include(donationCenter => donationCenter.BloodDonations).SingleOrDefaultAsync(DonationCenter => DonationCenter.Id == id);
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
    }
}
