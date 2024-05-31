using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models.DTOs;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Repositories;
using Blood_donate_App_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Blood_donate_App_Backend.Exceptions.Users_Exception;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.Blood_Donation_Center_Exception;

namespace BloodDonateApp_Unit_Test.ServiceBL
{
    public class UserServiceTest
    {
        private BloodDonateAppDbContext _context;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IConfiguration configuration = new InMemoryConfiguration().Configuration;

            IRepository<int, User> userRepository = new UserRepository(_context);
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository = new CenterAdminRelationRepository(_context);
            IRepository<int, DonationCenter> donationCenterRepository = new DonationCenterRepository(_context);
            ITokenService tokenService = new TokenServiceBL(configuration);
            _userService = new UserServiceBL(userRepository, userAuthDetailsRepository, donationCenterRepository, tokenService, centerAdminRelationRepository);
        }

        [TearDown]

        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task RegisterUserByMemberSuccessTest()
        {
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
                Role = "Member",
                Password = "dhoni123"
            };
            var result = await _userService.RegisterUser(userRegisterDTO);
            Assert.AreEqual(104, result.Id);
        }

        [Test]
        public async Task RegisterUserEmailExceptionTest()
        {
            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "Dhoni123",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "sakthi@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Member",
                Password = "dhoni123"
            };
            var result = Assert.ThrowsAsync<EmailAlreadyTakenException>(async () => await _userService.RegisterUser(userRegisterDTO));
            Assert.AreEqual("The email address is already Taken", result.Message);
        }

        [Test]
        public async Task UserNotRegisterExceptionTest()
        {
            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "Dhoni123",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "dhoni123@gmail.com",
                PostalCode = "641668",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Member",
                Password = "dhoni123"
            };
            var result = Assert.ThrowsAsync<UserNotRegisterException>(async () => await _userService.RegisterUser(userRegisterDTO));
            Assert.AreEqual("Error in registering the user", result.Message);
        }

        [Test]
        public async Task UserAuthDetailsNotRegisterExceptionTest()
        {
            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "Dhoni123",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "dhoni123@gmail.com",
                State = "tamil nadu",
                PostalCode = "641668",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Member",
            };
            var result = Assert.ThrowsAsync<UserNotRegisterException>(async () => await _userService.RegisterUser(userRegisterDTO));
            Assert.AreEqual("Error in registering the user", result.Message);
        }

        [Test]
        public async Task RegisterUserByCenterAdminSuccessTest()
        {
            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "virat",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "virat@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Center Admin",
                CenterId = 101,
                Password = "dhoni123"
            };
            var result = await _userService.RegisterUser(userRegisterDTO);
            Assert.AreEqual(104, result.Id);
        }

        [Test]
        public async Task DonationCenterNotAvailableExceptionTest()
        {
            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "virat",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "virat@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Center Admin",
                CenterId = 1000,
                Password = "dhoni123"
            };
            var result = Assert.ThrowsAsync<DonationCenterNotavailableException>(async () => await _userService.RegisterUser(userRegisterDTO));
            Assert.AreEqual("Donation center not available for id: 1000", result.Message);
        }

        [Test]
        public async Task LoginSuccessTest()
        {
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
                Role = "Member",
                Password = "dhoni123"
            };
            await _userService.RegisterUser(userRegisterDTO);
            LoginDTO loginDTO = new LoginDTO()
            {
                Email = "dhoni@gmail.com",
                Password = "dhoni123",
            };

            var result = await _userService.LoginUser(loginDTO);
            Assert.AreEqual(result.Email, loginDTO.Email);
        }

        [Test]
        public async Task AccountNotActiveExcpetionTest()
        {
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
            await _userService.RegisterUser(userRegisterDTO);
            LoginDTO loginDTO = new LoginDTO()
            {
                Email = "dhoni@gmail.com",
                Password = "dhoni123",
            };

            var result = Assert.ThrowsAsync<AccountNotActiveException>(async () => await _userService.LoginUser(loginDTO));
            Assert.AreEqual("Your account is not activated", result.Message);
        }

        [Test]
        public async Task InvalidEmailPasswordexceptionTest()
        {
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
            await _userService.RegisterUser(userRegisterDTO);
            LoginDTO loginDTO = new LoginDTO()
            {
                Email = "dhoni@gmail.com",
                Password = "dhoni1234",
            };

            var result = Assert.ThrowsAsync<InvalidEmailPasswordException>(async () => await _userService.LoginUser(loginDTO));
            Assert.AreEqual("Invalid Email and Password", result.Message);
        }

        [Test]
        public async Task UserAuthDetailsNotFoundByEmailExceptionTest()
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                Email = "dhoni@gmail.com",
                Password = "dhoni1234",
            };
            var result = Assert.ThrowsAsync<InvalidEmailPasswordException>(async () => await _userService.LoginUser(loginDTO));
            Assert.AreEqual("Invalid Email and Password", result.Message);
        }

        [Test]
        public async Task UserLoginExceptionTest()
        {
            LoginDTO loginDTO = null;
            var result = Assert.ThrowsAsync<UserNotLoginExpection>(async () => await _userService.LoginUser(loginDTO));
            Assert.AreEqual("Error during login the user", result.Message);
        }

        [Test]
        public async Task UpdateUserSuccessTest()
        {
            UserUpdateDTO userUpdateDTO = new UserUpdateDTO()
            {
                Id = 101,
                Name = "sakthi",
                Address = "101 abc street",
                City = "chennai",
                ContactNumber = "1234567890",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
            };
            var result = await _userService.UpdateUser(userUpdateDTO);
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task UserNotFoundExceptionTest()
        {
            UserUpdateDTO userUpdateDTO = new UserUpdateDTO()
            {
                Id = 107,
                Name = "sakthi",
                Address = "101 abc street",
                City = "chennai",
                ContactNumber = "1234567890",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
            };
            var result = Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.UpdateUser(userUpdateDTO));
            Assert.AreEqual("User not found with id: 107", result.Message);
        }

        [Test]
        public async Task UserUserNotUpdateExceptionTest()
        {
            UserUpdateDTO userUpdateDTO = null;
            var result = Assert.ThrowsAsync<UserNotUpdateException>(async () => await _userService.UpdateUser(userUpdateDTO));
            Assert.AreEqual("Error in updating the user in database", result.Message);
        }

        [Test]
        public async Task UsersListNotFoundExceptionTest()
        {
            IRepository<int, User> userRepository = null;
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository = new CenterAdminRelationRepository(_context);
            IRepository<int, DonationCenter> donationCenterRepository = new DonationCenterRepository(_context);
            ITokenService tokenService = null;
            IUserService _userService2 = new UserServiceBL(userRepository, userAuthDetailsRepository, donationCenterRepository, tokenService, centerAdminRelationRepository);

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
                Role = "Member",
                Password = "dhoni123"
            };

            var result = Assert.ThrowsAsync<UserNotRegisterException>(async () => await _userService2.RegisterUser(userRegisterDTO));
            Assert.AreEqual("Error in registering the user", result.Message);

        }

        [Test]
        public async Task BloodDonationCenterNotGetExceptionTest()
        {
            IRepository<int, User> userRepository = new UserRepository(_context);
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository = new CenterAdminRelationRepository(_context);
            IRepository<int, DonationCenter> donationCenterRepository = null;
            ITokenService tokenService = null;
            IUserService _userService2 = new UserServiceBL(userRepository, userAuthDetailsRepository, donationCenterRepository, tokenService, centerAdminRelationRepository);

            UserRegisterDTO userRegisterDTO = new UserRegisterDTO()
            {
                Name = "virat",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "virat@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Center Admin",
                CenterId = 101,
                Password = "dhoni123"
            };

            var result = Assert.ThrowsAsync<UserNotRegisterException>(async () => await _userService2.RegisterUser(userRegisterDTO));
            Assert.AreEqual("Error in registering the user", result.Message);
        }
    }
}

