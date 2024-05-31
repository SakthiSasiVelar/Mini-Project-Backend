using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
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
    public class UserRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private IRepository<int, User> userRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            userRepository = new UserRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task UserNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<UserNotFoundException>(async () =>await userRepository.Delete(1000));
            Assert.AreEqual("User not found with id: 1000", result.Message);
           
        }
        [Test]
        public async Task UserNotDeleteExceptionTest()
        {
            IRepository<int, User> userRepository2 = new UserRepository(null);
            var result = Assert.ThrowsAsync<UserNotDeleteException>(async ()=> await userRepository2.Delete(101));
            Assert.AreEqual("Error in deleting user in database", result.Message);
        }
        [Test]
        public async Task UsersListNotFoundExceptionTest()
        {
            IRepository<int, User> userRepository2 = new UserRepository(null);
            var result = Assert.ThrowsAsync<UsersListNotFoundException>(async () => await userRepository2.GetAll());
            Assert.AreEqual("Error in getting users list from database", result.Message);
        }
        [Test]
        public async Task UserNotFoundExceptionTest2()
        {
            User user = new User()
            {
                Id = 1000,
                Name = "ROHIT",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "rohit@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "CenterAdmin"
            };
            var result = Assert.ThrowsAsync<UserNotFoundException>(async () => await userRepository.Update(user));
            Assert.AreEqual("User not found with id: 1000", result.Message);

        }
        [Test]
        public async Task UserNotUpdateExceptionTest()
        {
            User user = new User()
            {
                Id = 1000,
                Name = "ROHIT",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "rohit@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "CenterAdmin"
            };
            IRepository<int, User> userRepository2 = new UserRepository(null);
            var result = Assert.ThrowsAsync<UserNotUpdateException>(async () => await userRepository2.Update(user));
            Assert.AreEqual("Error in updating the user in database", result.Message);
        }
    }
}
