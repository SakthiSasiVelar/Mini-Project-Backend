using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.Admin_Exception;
using Blood_donate_App_Backend.Exceptions.BloodRequest_Exception;
using Blood_donate_App_Backend.Exceptions.Users_Exception;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Models.DTOs;
using Blood_donate_App_Backend.Repositories;
using Blood_donate_App_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodDonateApp_Unit_Test.ServiceBL
{
    public class AdminServiceBLTest
    {
        private BloodDonateAppDbContext _context;
        private IAdminService adminService;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IRepository<int, User> userRepository = new UserRepository(_context);
            IRepository<int, RequestBlood> requestBloodRepository = new RequestBloodDetailsRepository(_context);
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            adminService = new AdminServiceBL(userRepository, userAuthDetailsRepository, requestBloodRepository);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task ActivateAdminSuccesTest()
        {
            IConfiguration configuration = new InMemoryConfiguration().Configuration;
            IRepository<int, User> userRepository = new UserRepository(_context);
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository = new CenterAdminRelationRepository(_context);
            IRepository<int, DonationCenter> donationCenterRepository = new DonationCenterRepository(_context);
            ITokenService tokenService = new TokenServiceBL(configuration);
            IUserService _userService = new UserServiceBL(userRepository, userAuthDetailsRepository, donationCenterRepository, tokenService, centerAdminRelationRepository);

            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "Dhoni",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "dhoni@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Admin",
                Password = "dhoni123"
            };
            var user = await _userService.RegisterUser(userRegisterDTO);
            var result = await adminService.ActivateAdmin(user.Id);
            Assert.AreEqual(user.Id, result.Id);
        }

        [Test]
        public async Task UserNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<UserNotFoundException>(async () => await adminService.ActivateAdmin(1));
            Assert.AreEqual("User not found with id: 1", result.Message);
        }

        [Test]
        public async Task UserAuthDetailsNotFoundByEmailExceptionTest()
        {
            var result = Assert.ThrowsAsync<UserAuthDetailsNotFoundByEmailException>(async () => await adminService.ActivateAdmin(103));
            Assert.AreEqual("Error in getting user auth details with email: rohit@gmail.com", result.Message);
        }

        [Test]
        public async Task ActivateAdminExceptionTest()
        {
            IRepository<int, User> userRepository = null;
            IRepository<int, RequestBlood> requestBloodRepository = new RequestBloodDetailsRepository(_context);
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IAdminService adminService2 = new AdminServiceBL(userRepository, userAuthDetailsRepository, requestBloodRepository);

            var result = Assert.ThrowsAsync<ActivateAdminException>(async () => await adminService2.ActivateAdmin(103));
            Assert.AreEqual("Error in activating the admin account with id: 103", result.Message);
        }
        [Test]
        public async Task ApproveRequestSuccessTest()
        {
            var result = await adminService.ApproveRequest(102);
            Assert.AreEqual("Approved", result.RequestApprovalStatus);
        }

        [Test]
        public async Task BloodRequestDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotFoundException>(async () => await adminService.ApproveRequest(1000));
            Assert.AreEqual("Blood request details not found with id: 1000", result.Message);
        }

        [Test]
        public async Task RequestApprovalExceptionTest()
        {
            IRepository<int, User> userRepository = null;
            IRepository<int, RequestBlood> requestBloodRepository = null;
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IAdminService adminService2 = new AdminServiceBL(userRepository, userAuthDetailsRepository, requestBloodRepository);

            var result = Assert.ThrowsAsync<RequestApprovalException>(async () => await adminService2.ApproveRequest(102));
            Assert.AreEqual("Error in approving the request with id: 102", result.Message);
        }
        [Test]
        public async Task RejectRequestSuccessTest()
        {
            RejectBloodRequestDTO rejectBloodRequestDTO = new RejectBloodRequestDTO()
            {
                Id = 102,
                RejectReason = "request details are invalid"
            };
            var result = await adminService.RejectRequest(rejectBloodRequestDTO);
            Assert.AreEqual("request details are invalid", result.RejectedReason);
        }

        [Test]

        public async Task BloodRequestDetailsNotFoundExceptionTest2()
        {
            RejectBloodRequestDTO rejectBloodRequestDTO = new RejectBloodRequestDTO()
            {
                Id = 1000,
                RejectReason = "request details are invalid"
            };
            var result = Assert.ThrowsAsync<BloodRequestDetailsNotFoundException>(async () => await adminService.RejectRequest(rejectBloodRequestDTO));
            Assert.AreEqual("Blood request details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task RequestRejectionExceptionTest()
        {
            IRepository<int, User> userRepository = null;
            IRepository<int, RequestBlood> requestBloodRepository = null;
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IAdminService adminService2 = new AdminServiceBL(userRepository, userAuthDetailsRepository, requestBloodRepository);

            RejectBloodRequestDTO rejectBloodRequestDTO = new RejectBloodRequestDTO()
            {
                Id = 102,
                RejectReason = "request details are invalid"
            };

            var result = Assert.ThrowsAsync<RequestRejectionException>(async () => await adminService2.RejectRequest(rejectBloodRequestDTO));
            Assert.AreEqual("Error in rejecting the request with id :102", result.Message);
        }
    }
}
