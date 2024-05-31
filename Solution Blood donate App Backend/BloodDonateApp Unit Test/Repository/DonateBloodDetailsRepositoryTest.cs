using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonateApp_Unit_Test.Repository
{
    public class DonateBloodDetailsRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private IRepository<int, DonateBlood> donateBloodDetailsRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            donateBloodDetailsRepository = new DonateBloodDetailsRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task BloodDonateDetailsNotAddExceptionTest()
        {
            IRepository<int, DonateBlood> donateBloodDetailsRepository2 = new DonateBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodDonateDetailsNotAddException>(async () => await donateBloodDetailsRepository2.Add(null));
            Assert.AreEqual("Error in adding blood donate details to database", result.Message);
        }
        [Test]
        public async Task DeleteSuccessTest()
        {
            var result = await donateBloodDetailsRepository.Delete(101);
            Assert.AreEqual(101 , result.Id);
        }
        [Test]
        public async Task BloodDonateDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodDonateDetailsNotFoundException>(async () => await donateBloodDetailsRepository.Delete(1000));
            Assert.AreEqual("Blood donate details not found with id: 1000", result.Message);
            
        }
        [Test]
        public async Task BloodDonateDetailsNotDeleteExceptionTest()
        {
            IRepository<int, DonateBlood> donateBloodDetailsRepository2 = new DonateBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodDonateDetailsNotDeleteException>(async () => await donateBloodDetailsRepository2.Delete(101));
            Assert.AreEqual("Error in deleting blood donate details in database", result.Message);
        }
        [Test]
        public async Task GetAllTest()
        {
            var result = await donateBloodDetailsRepository.GetAll();
            Assert.AreEqual(5, result.Count());
        }
        [Test]
        public async Task BloodDonateDetailsListNotFoundExceptionTest()
        {
            IRepository<int, DonateBlood> donateBloodDetailsRepository2 = new DonateBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodDonateDetailsListNotFoundException>(async ()=>await donateBloodDetailsRepository2.GetAll());
            Assert.AreEqual("Error in getting blood donate details list from database", result.Message);
        }
        [Test]
        public async Task BloodDonateDetailsNotFoundExceptionTest2()
        {
            DonateBlood donateBlood = new DonateBlood()
            {
                Id = 1000,
                UserId = 102,
                DonationType = "Center",
                CenterId = 101,
                RequestId = null,
                BloodType = "O",
                RhFactor = "positive",
                DonationStatus = "Donated",
                UnitsDonated = "5",
                DonateDateTime = DateTime.Now,
            };
            var result = Assert.ThrowsAsync<BloodDonateDetailsNotFoundException>(async () => await donateBloodDetailsRepository.Update(donateBlood));
            Assert.AreEqual("Blood donate details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task BloodDonateNotUpdateExceptionTest()
        {
            IRepository<int, DonateBlood> donateBloodDetailsRepository2 = new DonateBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodDonateNotUpdateException>(async () => await donateBloodDetailsRepository2.Update(null));
            Assert.AreEqual("Error in updating the blood donate details in database", result.Message);
        }
    }
}
