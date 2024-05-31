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
using Blood_donate_App_Backend.Exceptions.Inventory_Exceptions;

namespace BloodDonateApp_Unit_Test.ServiceBL
{
    public class InventoryServiceBLTest
    {
        private BloodDonateAppDbContext _context;
        private IInventoryService _inventoryService;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IRepository<int, Inventory> inventoryRepository = new InventoryRepositoryDetails(_context);
            _inventoryService = new InventoryServiceBL(inventoryRepository);
        }

        [TearDown]

        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddInventorySuccessTest()
        {
            InventoryAddDTO inventoryAddDTO = new InventoryAddDTO()
            {
                CenterId = 101,
                DonorId = 102,
                BloodType = "O",
                RhFactor = "positive",
                Units = "20",
                CollectedDateTime = DateTime.Now,
                ExpiryDateTime = DateTime.Now,
                StorageLocation = "2 nd rack",
            };

            var result = await _inventoryService.AddInventory(inventoryAddDTO);
            Assert.AreEqual(102, result.InventoryId);
        }

        [Test]
        public async Task InventoryNotAddExceptionTest()
        {
            InventoryAddDTO inventoryAddDTO = null;
            var result = Assert.ThrowsAsync<InventoryNotAddException>(async () => await _inventoryService.AddInventory(inventoryAddDTO));
            Assert.AreEqual("Error in adding inventory details to database", result.Message);
        }
    }
}
