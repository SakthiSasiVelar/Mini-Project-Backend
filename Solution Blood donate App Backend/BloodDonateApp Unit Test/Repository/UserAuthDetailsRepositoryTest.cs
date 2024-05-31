using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Exceptions.UserAuthDetails_Exception;
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
    public class UserAuthDetailsRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private IUserAuthDetailsRepository<int,UserAuthDetails> userAuthDetailsRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            userAuthDetailsRepository = new UserAuthDetailsRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task UserAuthDetailsNotAddExceptionTest()
        {
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository2 = new UserAuthDetailsRepository(null);
            UserAuthDetails userAuthDetails = null;

            var result = Assert.ThrowsAsync<UserAuthDetailsNotAddException>(async () => await userAuthDetailsRepository2.Add(userAuthDetails));
            Assert.AreEqual("Error in adding user auth details to database", result.Message);
        }
        [Test]
        public async Task UserAuthDetailsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<UserAuthDetailsNotFoundException>(async () => await userAuthDetailsRepository.Delete(1));
            Assert.AreEqual("User auth details not found with id: 1", result.Message);
        }
        [Test]
        public async Task UserAuthDetailsNotDeleteExceptionTest()
        {
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository2 = new UserAuthDetailsRepository(null);
            var result = Assert.ThrowsAsync<UserAuthDetailsNotDeleteException>(async ()=> await userAuthDetailsRepository2.Delete(1));
            Assert.AreEqual("Error in deleting user auth details in database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await userAuthDetailsRepository.GetAll();
            Assert.AreEqual(0, result.Count());
        }
        [Test]
        public async Task UserAuthDetailsListNotFoundExceptionTest()
        {
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository2 = new UserAuthDetailsRepository(null);
            var result = Assert.ThrowsAsync<UserAuthDetailsListNotFoundException>(async () => await userAuthDetailsRepository2.GetAll());
            Assert.AreEqual("Error in getting users auth details list from database", result.Message);
        }
        [Test]
        public async Task UserNotGetExceptionTest()
        {
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository2 = new UserAuthDetailsRepository(null);
            var result = Assert.ThrowsAsync<UserNotGetException>(async () => await userAuthDetailsRepository2.GetByEmail("sakthi@gmail.com"));
            Assert.AreEqual("Error in getting user from database", result.Message);
        }

        [Test]
        public async Task UserAuthDetailsNotFoundExceptionTest2()
        {

            UserAuthDetails userAuthDetails = new UserAuthDetails()
            {
                Id = 1,
                Email = "sakthi@gmail.com",
                Password = Encoding.UTF8.GetBytes("heybro"),
                PasswordHashKey = Encoding.UTF8.GetBytes("1234"),
                Role = "Member",
                IsActive = false,
            };
            var result = Assert.ThrowsAsync<UserAuthDetailsNotFoundException>(async () => await userAuthDetailsRepository.Update(userAuthDetails));
            Assert.AreEqual("User auth details not found with id: 1", result.Message);
        }
        [Test]
        public async Task UserAuthDetailsNotUpdateExceptionTest()
        {
            IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository2 = new UserAuthDetailsRepository(null);
            var result = Assert.ThrowsAsync<UserAuthDetailsNotUpdateException>(async () => await userAuthDetailsRepository2.Update(null));
            Assert.AreEqual("Error in updating the user auth details in database", result.Message);
        }
    }
}
