using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonateApp_Unit_Test.Repository
{
    public class DonationCenterBloodDonationRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private DonationCenterBloodDonationRepository donationCenterBloodDonationRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            donationCenterBloodDonationRepository = new DonationCenterBloodDonationRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task BloodDonationCenterNotGetExceptionTest()
        {
            DonationCenterBloodDonationRepository donationCenterBloodDonationRepository2 = new DonationCenterBloodDonationRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterNotGetException>(async () => await donationCenterBloodDonationRepository2.GetById(101));
            Assert.AreEqual("Error in getting blood donation center details from database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await donationCenterBloodDonationRepository.GetAll();
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task BloodDonationCenterListNotFoundExceptionTest()
        {
            DonationCenterBloodDonationRepository donationCenterBloodDonationRepository2 = new DonationCenterBloodDonationRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterListNotFoundException>(async () => await donationCenterBloodDonationRepository2.GetAll());
            Assert.AreEqual("Error in getting blood donation center details list from database", result.Message);
        }
        [Test]
        public async Task BloodDonationCenterNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodDonationCenterNotFoundException>(async () => await donationCenterBloodDonationRepository.GetById(1000));
            Assert.AreEqual("Blood donation center details not found with id: 1000", result.Message);
        }

    }
}
