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
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;
using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodDonateApp_Unit_Test.ServiceBL
{
    public class DonationCenterServiceBLTest
    {
        private BloodDonateAppDbContext _context;
        private IDonationCenterService _donationCenterService;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IRepository<int, DonationCenter> _donationCenterRepository = new DonationCenterRepository(_context);
            DonationCenterInventoryRepository _donationCenterInventoryRepository = new DonationCenterInventoryRepository(_context);
            _donationCenterService = new DonationCenterServiceBL(_donationCenterRepository, _donationCenterInventoryRepository);
        }

        [TearDown]

        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]

        public async Task AddDonationCenterSuccessTest()
        {
            DonationCenterDTO donationCenterDTO = new DonationCenterDTO()
            {
                Name = "center 3",
                Address = "107 abc street trichy",
                City = "chennai",
                State = "tamil nadu",
                PostalCode = "641668",
                ContactNumber = "1234567890",
                OperatingHours = "10 AM to 4 PM"
            };

            var result = await _donationCenterService.AddDonationCenter(donationCenterDTO);
            Assert.AreEqual(103, result.DonationCenterId);
        }

        [Test]

        public async Task BloodDonationCenterNotAddExceptionTest()
        {
            DonationCenterDTO donationCenterDTO = null;
            var result = Assert.ThrowsAsync<BloodDonationCenterNotAddException>(async () => await _donationCenterService.AddDonationCenter(donationCenterDTO));
            Assert.AreEqual("Error in adding blood donation center  details to database", result.Message);
        }

        [Test]
        public async Task GetDonationCenterBloodUnitsByIdSuccessTest()
        {
            var result = await _donationCenterService.GetDonationCenterBloodUnitsById(101);
            Assert.AreEqual("5", result.OPositive.ToString());
        }

        [Test]
        public async Task BloodDonationCenterNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodDonationCenterNotFoundException>(async () => await _donationCenterService.GetDonationCenterBloodUnitsById(1001));
            Assert.AreEqual("Blood donation center details not found with id: 1001", result.Message);
        }

        [Test]
        public async Task GetDonationCenterBloodUnitsByIdExceptionTest()
        {
            IRepository<int, DonationCenter> _donationCenterRepository = new DonationCenterRepository(_context);
            DonationCenterInventoryRepository _donationCenterInventoryRepository = null;
            IDonationCenterService _donationCenterService2 = new DonationCenterServiceBL(_donationCenterRepository, _donationCenterInventoryRepository);

            var result = Assert.ThrowsAsync<GetDonationCenterBloodUnitsByIdException>(async () => await _donationCenterService2.GetDonationCenterBloodUnitsById(101));
            Assert.AreEqual("Error in getting blood units from donation center of id: 101", result.Message);
        }

        [Test]
        public async Task GetDonationCenterByStateAndCity()
        {
            GetDonationCenterByStateAndCityDTO getDonationCenterByStateAndCityDTO = new GetDonationCenterByStateAndCityDTO()
            {
                State = "tamil nadu",
                City = "cbe"
            };
            var result = await _donationCenterService.GetDonationCenterByStateAndCity(getDonationCenterByStateAndCityDTO);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task GetDonationCenterByStateAndCityExceptionTest()
        {
            IRepository<int, DonationCenter> _donationCenterRepository = null;
            DonationCenterInventoryRepository _donationCenterInventoryRepository = null;
            IDonationCenterService _donationCenterService2 = new DonationCenterServiceBL(_donationCenterRepository, _donationCenterInventoryRepository);

            GetDonationCenterByStateAndCityDTO getDonationCenterByStateAndCityDTO = new GetDonationCenterByStateAndCityDTO()
            {
                State = "tamil nadu",
                City = "cbe"
            };
            var result = Assert.ThrowsAsync<GetDonationCenterByStateAndCityException>(async () => await _donationCenterService2.GetDonationCenterByStateAndCity(getDonationCenterByStateAndCityDTO));
            Assert.AreEqual("error in getting donation center list by state and city", result.Message);
        }
    }
}
