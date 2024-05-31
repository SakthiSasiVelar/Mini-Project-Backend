using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.Request_Exception;
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
    public class RequestBloodDetailsRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private IRepository<int, RequestBlood> requestBloodRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            requestBloodRepository = new RequestBloodDetailsRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task BloodRequestDetailsNotAddExceptionTest()
        {
            IRepository<int, RequestBlood> requestBloodRepository2 = new RequestBloodDetailsRepository(null);
            
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotAddException>(async () => await requestBloodRepository2.Add(null));
            Assert.AreEqual("Error in adding blood request details to database", result.Message);
        }
        [Test]
        public async Task DeleteSuccessTest()
        {
            var result = await requestBloodRepository.Delete(102);
            Assert.AreEqual(102 , result.Id);
        }
        [Test]
        public async Task BloodRequestDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotFoundException>(async () => await requestBloodRepository.Delete(1000));
            Assert.AreEqual("Blood request details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsNotDeleteExceptionTest()
        {
            IRepository<int, RequestBlood> requestBloodRepository2 = new RequestBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotDeleteException>(async ()=>await  requestBloodRepository2.Delete(102));
            Assert.AreEqual("Error in deleting blood request details in database", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsListNotFoundExceptionTest()
        {
            IRepository<int, RequestBlood> requestBloodRepository2 = new RequestBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodRequestDetailsListNotFoundException>(async ()=>await requestBloodRepository2.GetAll());
            Assert.AreEqual("Error in getting blood request details list from database", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsNotFoundExceptionTest2()
        {
            RequestBlood requestBlood = new RequestBlood()
            {
                Id = 1000,
                UserId = 102,
                BloodType = "B",
                RhFactor = "positive",
                UnitsNeeded = "50",
                UnitsCollected = "0",
                Urgency = "Immediate",
                RequestedDateTime = DateTime.Now,
                Description = "need b+ blood",
                FulfillmentStatus = "NotFulfilled",
                HospitalName = "KMCH",
                HospitalAddress = "123 , ABC cbe",
                DoctorName = "sasi",
                DoctorContactNumber = "1234567890",
                RequestedContactNumber = "12345656789",
                RequestApprovalStatus = "Pending",
                PatientName = "ramu",
                RejectReason = "NULL"
            };
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotFoundException>(async ()=>await requestBloodRepository.Update(requestBlood));
            Assert.AreEqual("Blood request details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsNotUpdateExceptionTest()
        {
            IRepository<int, RequestBlood> requestBloodRepository2 = new RequestBloodDetailsRepository(null);
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotUpdateException>(async () => await requestBloodRepository2.Update(null));
            Assert.AreEqual("Error in updating the blood request details in database", result.Message);
        }
    }
}
