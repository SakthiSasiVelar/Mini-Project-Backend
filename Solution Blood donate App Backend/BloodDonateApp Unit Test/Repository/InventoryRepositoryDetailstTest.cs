using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Inventory_Exceptions;
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
    public class InventoryRepositoryDetailstTest
    {
        private BloodDonateAppDbContext _context;
        private IRepository<int, Inventory> inventoryRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            inventoryRepository = new InventoryRepositoryDetails(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task InventoryNotAddExceptionTest()
        {
            IRepository<int, Inventory> inventoryRepository2 = new InventoryRepositoryDetails(null);
            var result = Assert.ThrowsAsync<InventoryNotAddException>(async () => await inventoryRepository2.Add(null));
            Assert.AreEqual("Error in adding inventory details to database", result.Message);
        }
        [Test]
        public async Task DeleteSuccessTest()
        {
            var result = await inventoryRepository.Delete(101);
            Assert.AreEqual(101, result.Id);
        }
        [Test]
        public async Task InventoryNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<InventoryNotFoundException>(async () => await inventoryRepository.Delete(1000));
            Assert.AreEqual("Inventory details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task InventoryNotDeleteExceptionTest()
        {
            IRepository<int, Inventory> inventoryRepository2 = new InventoryRepositoryDetails(null);
            var result = Assert.ThrowsAsync<InventoryNotDeleteException>(async () => await inventoryRepository2.Delete(101));
            Assert.AreEqual("Error in deleting inventory details in database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await inventoryRepository.GetAll();
            Assert.AreEqual(1, result.Count());
        }
        [Test]
        public async Task InventoryListNotFoundExceptionTest()
        {
            IRepository<int, Inventory> inventoryRepository2 = new InventoryRepositoryDetails(null);
            var result = Assert.ThrowsAsync<InventoryListNotFoundException>(async ()=>await inventoryRepository2.GetAll());
            Assert.AreEqual("Error in getting inventory details list from database", result.Message);
        }
        [Test]
        public async Task UpdateSuccessTest()
        {
            Inventory inventory = new Inventory()
            {
                Id = 101,
                CenterId = 101,
                DonorId = 102,
                BloodType = "O",
                RhFactor = "positive",
                Units = "15",
                CollectedDateTime = DateTime.Now,
                ExpiryDateTime = DateTime.Now,
                StorageLocation = "1 rack",
                AvailableStatus = true
            };
            var result = await inventoryRepository.Update(inventory);
            Assert.AreEqual("15" , result.Units);
        }
        [Test]
        public async Task InventoryNotFoundExceptionTest2()
        {
            Inventory inventory = new Inventory()
            {
                Id = 1000,
                CenterId = 101,
                DonorId = 102,
                BloodType = "O",
                RhFactor = "positive",
                Units = "15",
                CollectedDateTime = DateTime.Now,
                ExpiryDateTime = DateTime.Now,
                StorageLocation = "1 rack",
                AvailableStatus = true
            };
            var result = Assert.ThrowsAsync<InventoryNotFoundException>(async () => await inventoryRepository.Update(inventory));
            Assert.AreEqual("Inventory details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task InventoryNotUpdateExceptionTest()
        {
            IRepository<int, Inventory> inventoryRepository2 = new InventoryRepositoryDetails(null);
            var result = Assert.ThrowsAsync<InventoryNotUpdateException>(async () => await inventoryRepository2.Update(null));
            Assert.AreEqual("Error in updating the inventory details in database", result.Message);
        }

    }
}
