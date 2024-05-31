using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
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
    public class RequestBloodDonationRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private RequestBloodDonationRepository requestBloodDonationRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            requestBloodDonationRepository = new RequestBloodDonationRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await requestBloodDonationRepository.GetAll();
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task BloodRequestDetailsListNotFoundExceptionTest()
        {
            RequestBloodDonationRepository requestBloodDonationRepository2 = new RequestBloodDonationRepository(null);
            var result = Assert.ThrowsAsync<BloodRequestDetailsListNotFoundException>(async ()=>await  requestBloodDonationRepository2.GetAll());
            Assert.AreEqual("Error in getting blood request details list from database", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotFoundException>(async () => await requestBloodDonationRepository.GetById(1000));
            Assert.AreEqual("Blood request details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsNotGetExceptionTest()
        {
            RequestBloodDonationRepository requestBloodDonationRepository2 = new RequestBloodDonationRepository(null);
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotGetException>(async () => await requestBloodDonationRepository2.GetById(102));
            Assert.AreEqual("Error in getting blood request details from database", result.Message);
        }
    }
}
