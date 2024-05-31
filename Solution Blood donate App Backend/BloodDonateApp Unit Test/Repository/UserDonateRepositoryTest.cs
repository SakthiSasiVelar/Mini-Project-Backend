using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions;
using Blood_donate_App_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonateApp_Unit_Test.Repository
{
    public class UserDonateRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private UserDonateRepository userDonateRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            userDonateRepository = new UserDonateRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task GetByIdSuccessTest()
        {
            var result = await userDonateRepository.GetById(102);
            Assert.AreEqual(5, result.DonateHistory.Count());
        }
        [Test]
        public async Task UserNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<UserNotFoundException>(async () => await userDonateRepository.GetById(1000));
            Assert.AreEqual("User not found with id: 1000", result.Message);
        }
        [Test]
        public async Task UserNotGetExceptionTest()
        {
            UserDonateRepository userDonateRepository2 = new UserDonateRepository(null);
            var result = Assert.ThrowsAsync<UserNotGetException>(async () => await userDonateRepository2.GetById(102));
            Assert.AreEqual("Error in getting user from database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await userDonateRepository.GetAll();
            Assert.AreEqual(3, result.Count());
        }
        [Test]
        public async Task UsersListNotFoundExceptionTest()
        {
            UserDonateRepository userDonateRepository2 = new UserDonateRepository(null);
            var result = Assert.ThrowsAsync<UsersListNotFoundException>(async () => await userDonateRepository2.GetAll());
            Assert.AreEqual("Error in getting users list from database", result.Message);
        }
    }
}
