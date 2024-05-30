using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.BloodDonate_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using Blood_donate_App_Backend.Repositories;
using Blood_donate_App_Backend.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodDonateApp_Unit_Test.ServiceBL
{
    public class DonateServiceBLTest
    {
        private BloodDonateAppDbContext _context;
        private IDonateService _donateService;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IRepository<int, DonateBlood> _donateRepository = new DonateBloodDetailsRepository(_context);
            IRepository<int, RequestBlood> _requestBloodRepository = new RequestBloodDetailsRepository(_context);
            RequestBloodDonationRepository _requestBloodDonationRepository = new RequestBloodDonationRepository(_context);
            DonationCenterBloodDonationRepository _donationCenterBloodDonationRepository = new DonationCenterBloodDonationRepository(_context);
            _donateService = new DonateServiceBL(_donateRepository, _requestBloodRepository, _donationCenterBloodDonationRepository, _requestBloodDonationRepository);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task ApproveDonationByCenterSuccessTest()
        {
            var result = await _donateService.ApproveDonationByCenter(103);
            Assert.AreEqual("Donated", result.DonationStatus);
        }

        [Test]
        public async Task BloodDonateDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodDonateDetailsNotFoundException>(async () => await _donateService.ApproveDonationByCenter(108));
            Assert.AreEqual("Blood donate details not found with id: 108", result.Message);
        }

        [Test]
        public async Task ApproveDonationExceptionTest()
        {
            IRepository<int, DonateBlood> _donateRepository = null;
            IRepository<int, RequestBlood> _requestBloodRepository = new RequestBloodDetailsRepository(_context);
            RequestBloodDonationRepository _requestBloodDonationRepository = new RequestBloodDonationRepository(_context);
            DonationCenterBloodDonationRepository _donationCenterBloodDonationRepository = new DonationCenterBloodDonationRepository(_context);
            IDonateService _donateService2 = new DonateServiceBL(_donateRepository, _requestBloodRepository, _donationCenterBloodDonationRepository, _requestBloodDonationRepository);

            var result = Assert.ThrowsAsync<ApproveDonationException>(async () => await _donateService2.ApproveDonationByCenter(102));
            Assert.AreEqual("Error in approving the blood donation details of id: 102", result.Message);
        }

        [Test]
        public async Task ApproveDonationByRequesterSuccessTest()
        {
            await _donateService.ApproveDonationByRequester(104);
            var result = await _donateService.ApproveDonationByRequester(101);
            Assert.AreEqual("Donated", result.DonationStatus);
        }

        [Test]
        public async Task BloodDonateDetailsNotFoundExceptionTest2()
        {
            var result = Assert.ThrowsAsync<BloodDonateDetailsNotFoundException>(async () => await _donateService.ApproveDonationByRequester(106));
            Assert.AreEqual("Blood donate details not found with id: 106", result.Message);
        }
        [Test]
        public async Task BloodRequestDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotFoundException>(async () => await _donateService.ApproveDonationByRequester(105));
            Assert.AreEqual("Blood request details not found with id: 110", result.Message);
        }

        [Test]
        public async Task ApproveDonationExceptionTest2()
        {
            IRepository<int, DonateBlood> _donateRepository = null;
            IRepository<int, RequestBlood> _requestBloodRepository = new RequestBloodDetailsRepository(_context);
            RequestBloodDonationRepository _requestBloodDonationRepository = new RequestBloodDonationRepository(_context);
            DonationCenterBloodDonationRepository _donationCenterBloodDonationRepository = new DonationCenterBloodDonationRepository(_context);
            IDonateService _donateService2 = new DonateServiceBL(_donateRepository, _requestBloodRepository, _donationCenterBloodDonationRepository, _requestBloodDonationRepository);

            var result = Assert.ThrowsAsync<ApproveDonationException>(async () => await _donateService2.ApproveDonationByRequester(102));
            Assert.AreEqual("Error in approving the blood donation details of id: 102", result.Message);
        }

        [Test]
        public async Task DonateBloodToCenterSuccessTest()
        {
            DonateBloodForCenterDTO donateBloodForCenterDTO = new DonateBloodForCenterDTO()
            {
                UserId = 102,
                CenterId = 102,
                BloodType = "AB",
                RhFactor = "positive",
                UnitsDonated = "5",
                DonateDateTime = DateTime.Now,
            };
            var result = await _donateService.DonateBloodToCenter(donateBloodForCenterDTO);
            Assert.AreEqual(106, result.DonationId);
        }
        [Test]
        public async Task BloodDonateDetailsNotFoundExceptionTest3()
        {
            DonateBloodForCenterDTO donateBloodForCenterDTO = null;

            var result = Assert.ThrowsAsync<BloodDonateDetailsNotAddException>(async () => await _donateService.DonateBloodToCenter(donateBloodForCenterDTO));
            Assert.AreEqual("Error in adding blood donate details to database", result.Message);
        }
        [Test]
        public async Task DonateBloodToRequesterSuccessTest()
        {
            DonateBloodForRequestDTO donateBloodForRequestDTO = new DonateBloodForRequestDTO()
            {
                UserId = 102,
                RequestId = 102,
                BloodType = "AB",
                RhFactor = "positive",
                UnitsDonated = "5",
                DonateDateTime = DateTime.Now,
            };
            var result = await _donateService.DonateBloodToRequester(donateBloodForRequestDTO);
            Assert.AreEqual(106, result.DonationId);
        }
        [Test]
        public async Task BloodDonateDetailsNotFoundExceptionTest4()
        {
            DonateBloodForRequestDTO donateBloodForRequestDTO = null;

            var result = Assert.ThrowsAsync<BloodDonateDetailsNotAddException>(async () => await _donateService.DonateBloodToRequester(donateBloodForRequestDTO));
            Assert.AreEqual("Error in adding blood donate details to database", result.Message);
        }

        [Test]
        public async Task NotDonatedBloodDetailsListForCenterSuccessTest()
        {
            var result = await _donateService.NotDonatedBloodDetailsListForCenter(102);
            Assert.AreEqual(1, result.Count());
        }
        [Test]
        public async Task NotdonatedBloodListForCenterIdExceptionTest()
        {
            IRepository<int, DonateBlood> _donateRepository = new DonateBloodDetailsRepository(_context);
            IRepository<int, RequestBlood> _requestBloodRepository = new RequestBloodDetailsRepository(_context);
            RequestBloodDonationRepository _requestBloodDonationRepository = new RequestBloodDonationRepository(_context);
            DonationCenterBloodDonationRepository _donationCenterBloodDonationRepository = null;
            IDonateService _donateService2 = new DonateServiceBL(_donateRepository, _requestBloodRepository, _donationCenterBloodDonationRepository, _requestBloodDonationRepository);

            var result = Assert.ThrowsAsync<NotdonatedBloodListForCenterIdException>(async () => await _donateService2.NotDonatedBloodDetailsListForCenter(102));
            Assert.AreEqual("Error in getting Not donated Blood List for center id: 102", result.Message);
        }

        [Test]
        public async Task NotDonatedBloodDetailsListForRequesterSuccessTest()
        {
            var result = await _donateService.NotDonatedBloodDetailsListForRequester(101);
            Assert.AreEqual(1, result.Count());
        }
        [Test]
        public async Task NotdonatedBloodListForRequestIdExceptionTest()
        {
            IRepository<int, DonateBlood> _donateRepository = new DonateBloodDetailsRepository(_context);
            IRepository<int, RequestBlood> _requestBloodRepository = new RequestBloodDetailsRepository(_context);
            RequestBloodDonationRepository _requestBloodDonationRepository = null;
            DonationCenterBloodDonationRepository _donationCenterBloodDonationRepository = null;
            IDonateService _donateService2 = new DonateServiceBL(_donateRepository, _requestBloodRepository, _donationCenterBloodDonationRepository, _requestBloodDonationRepository);

            var result = Assert.ThrowsAsync<NotDonatedBloodListForRequestIdGetException>(async () => await _donateService2.NotDonatedBloodDetailsListForRequester(101));
            Assert.AreEqual("Error in getting Not donated Blood List for requestID : 101", result.Message);
        }

    }
}
