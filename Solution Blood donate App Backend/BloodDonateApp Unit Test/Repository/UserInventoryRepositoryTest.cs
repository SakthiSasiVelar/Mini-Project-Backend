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
    public class UserInventoryRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private UserInventoryRepository userInventoryRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            userInventoryRepository = new UserInventoryRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task GetByIdSuccessTest()
        {
            var result = await userInventoryRepository.GetById(102);
            Assert.AreEqual(1, result.Inventories.Count());
        }
        [Test]
        public async Task UserNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<UserNotFoundException>(async () => await userInventoryRepository.GetById(1000));
            Assert.AreEqual("User not found with id: 1000", result.Message);
        }
        [Test]
        public async Task UserNotGetExceptionTest()
        {
            UserInventoryRepository userInventoryRepository2 = new UserInventoryRepository(null);
            var result = Assert.ThrowsAsync<UserNotGetException>(async () => await userInventoryRepository2.GetById(102));
            Assert.AreEqual("Error in getting user from database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await userInventoryRepository.GetAll();
            Assert.AreEqual(3, result.Count());
        }
        [Test]
        public async Task UsersListNotFoundExceptionTest()
        {
            UserInventoryRepository userInventoryRepository2 = new UserInventoryRepository(null);
            var result = Assert.ThrowsAsync<UsersListNotFoundException>(async () => await userInventoryRepository2.GetAll());
            Assert.AreEqual("Error in getting users list from database", result.Message);
        }
    }
}
