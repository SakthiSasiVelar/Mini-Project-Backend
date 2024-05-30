using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Repositories;
using Blood_donate_App_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blood_donate_App_Backend.Exceptions.Request_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;

namespace BloodDonateApp_Unit_Test.ServiceBL
{
    public class RequestServiceBLTest
    {
        private BloodDonateAppDbContext _context;
        private IRequestService _requestService;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IRepository<int, RequestBlood> requestBloodRepository = new RequestBloodDetailsRepository(_context);
            _requestService = new RequestServiceBL(requestBloodRepository);
        }

        [TearDown]

        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddRequestSuccessTest()
        {
            BloodRequestDTO bloodRequestDTO = new BloodRequestDTO()
            {
                UserId = 102,
                BloodType = "A",
                RhFactor = "positive",
                UnitsNeeded = "50",
                Urgency = "Immediate",
                RequestedDateTime = DateTime.Now,
                Description = "need A+ blood",
                HospitalName = "KMCH",
                HospitalAddress = "123 , ABC cbe",
                DoctorName = "sasi",
                DoctorContactNumber = "1234567890",
                RequestedContactNumber = "12345656789",
                PatientName = "ramu",
            };
            var result = await _requestService.RequestBlood(bloodRequestDTO);
            Assert.AreEqual(103, result.RequestId);
        }

        [Test]
        public async Task BloodRequestDetailsNotAddExceptionTest()
        {
            BloodRequestDTO bloodRequestDTO = null;
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotAddException>(async () => await _requestService.RequestBlood(bloodRequestDTO));
            Assert.AreEqual("Error in adding blood request details to database", result.Message);
        }

        [Test]

        public async Task GetAllPendingRequestSuccessTest()
        {
            var result = await _requestService.GetAllPendingRequest();
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task GetAllApprovedRequestSuccessTest()
        {
            var result = await _requestService.GetAllApprovedRequest();
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task BloodRequestDetailsListNotFoundExceptionTest()
        {
            IRepository<int, RequestBlood> requestBloodRepository = null;
            IRequestService _requestService2 = new RequestServiceBL(requestBloodRepository);

            var result = Assert.ThrowsAsync<BloodRequestDetailsListNotFoundException>(async () => await _requestService2.GetAllPendingRequest());
            Assert.AreEqual("Error in getting blood request details list from database", result.Message);

            var result2 = Assert.ThrowsAsync<BloodRequestDetailsListNotFoundException>(async () => await _requestService2.GetAllApprovedRequest());
            Assert.AreEqual("Error in getting blood request details list from database", result.Message);

        }



    }
}
