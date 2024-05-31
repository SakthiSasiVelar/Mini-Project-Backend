using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using Blood_donate_App_Backend.Exceptions.Inventory_Exceptions;
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
    public class DonationCenterRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private IRepository<int, DonationCenter> donationCenterRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            donationCenterRepository = new DonationCenterRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task BloodDonationCenterNotAddExceptionTest()
        {
            IRepository<int, DonationCenter> donationCenterRepository2 = new DonationCenterRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterNotAddException>(async () => await donationCenterRepository2.Add(null));
            Assert.AreEqual("Error in adding blood donation center  details to database", result.Message);
        }
        [Test]
        public async Task DeleteSuccessTest()
        {
            var result = await donationCenterRepository.Delete(101);
            Assert.AreEqual(101 , result.Id);
        }
        [Test]
        public async Task BloodDonationCenterNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodDonationCenterNotFoundException>(async () => await donationCenterRepository.Delete(1000));
            Assert.AreEqual("Blood donation center details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task BloodDonationCenterNotDeleteExceptionTest()
        {
            IRepository<int, DonationCenter> donationCenterRepository2 = new DonationCenterRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterNotDeleteException>(async ()=> await donationCenterRepository2.Delete(101));
            Assert.AreEqual("Error in deleting blood donation center details in database", result.Message);
        }
        [Test]
        public async Task BloodDonationCenterListNotFoundExceptionTest()
        {
            IRepository<int, DonationCenter> donationCenterRepository2 = new DonationCenterRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterListNotFoundException>(async () => await donationCenterRepository2.GetAll());
            Assert.AreEqual("Error in getting blood donation center details list from database", result.Message);
        }
        [Test]
        public async Task UpdateSuccessTest()
        {
            DonationCenter donationCenter = new DonationCenter()
            {
                Id = 101,
                Name = "center 1",
                Address = "100 abc street cbe",
                City = "cbe",
                State = "tamil nadu",
                PostalCode = "641669",
                ContactNumber = "1234567890",
                OperatingHours = "10 AM to 4 PM"
            };
            var result = await donationCenterRepository.Update(donationCenter);
            Assert.AreEqual("641669", result.PostalCode);
        }
        [Test]
        public async Task BloodDonationCenterNotFoundExceptionTest2()
        {
            DonationCenter donationCenter = new DonationCenter()
            {
                Id = 1000,
                Name = "center 1",
                Address = "100 abc street cbe",
                City = "cbe",
                State = "tamil nadu",
                PostalCode = "641669",
                ContactNumber = "1234567890",
                OperatingHours = "10 AM to 4 PM"
            };
            var result = Assert.ThrowsAsync<BloodDonationCenterNotFoundException>(async () => await donationCenterRepository.Update(donationCenter));
            Assert.AreEqual("Blood donation center details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task BloodDonationCenterNotUpdateExceptionTest()
        {
            IRepository<int, DonationCenter> donationCenterRepository2 = new DonationCenterRepository(null);
            var result = Assert.ThrowsAsync<BloodDonationCenterNotUpdateException>(async ()=>await donationCenterRepository2.Update(null));
            Assert.AreEqual("Error in updating the blood donation details in database", result.Message);
        }
    }
}
