using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonateApp_Unit_Test.Repository
{
    public class DonationCenterInventoryRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private DonationCenterInventoryRepository donationCenterInventoryRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            donationCenterInventoryRepository = new DonationCenterInventoryRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task BloodDonationCenterNotGetExceptionTest()
        {
            DonationCenterInventoryRepository donationCenterInventoryRepository2 = new DonationCenterInventoryRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterNotGetException>(async () => await donationCenterInventoryRepository2.GetById(101));
            Assert.AreEqual("Error in getting blood donation center details from database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await donationCenterInventoryRepository.GetAll();
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task BloodDonationCenterListNotFoundExceptionTest()
        {
            DonationCenterInventoryRepository donationCenterInventoryRepository2 = new DonationCenterInventoryRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterListNotFoundException>(async () => await donationCenterInventoryRepository2.GetAll());
            Assert.AreEqual("Error in getting blood donation center details list from database", result.Message);
        }
    }
}
