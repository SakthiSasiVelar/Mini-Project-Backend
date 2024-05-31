using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Exceptions.Center_Admin_Relation_Exceptions;
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
    public class CenterAdminRelationRepositoryTest
    {
        private BloodDonateAppDbContext _context;
        private IRepository<int, CenterAdminRelation> centerAdminRelationRepository;

        [SetUp]
        public void SetUp()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("BloodDonateAppDb");
            _context = new BloodDonateAppDbContext(dbContextOptionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            centerAdminRelationRepository = new CenterAdminRelationRepository(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
        [Test]
        public async Task CenterAdminRelationDetailsNotAddExceptionTest()
        {
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository2 = new CenterAdminRelationRepository(null);
            var result = Assert.ThrowsAsync<CenterAdminRelationDetailsNotAddException>(async () => await centerAdminRelationRepository.Add(null));
            Assert.AreEqual("Error in adding center admin relation details to database", result.Message);
        }
        [Test]
        public async Task DeleteSuccessTest()
        {
            var result = await centerAdminRelationRepository.Delete(101);
            Assert.AreEqual(101 , result.Id);
        }
        [Test]
        public async Task CenterAdminRelationsNotFoundExceptionTest()
        {
            var result = Assert.ThrowsAsync<CenterAdminRelationsNotFoundException>(async () => await centerAdminRelationRepository.Delete(1000));
            Assert.AreEqual("Center admin relation details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task CenterAdminRelationsNotDeleteExceptionTest()
        {
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository2 = new CenterAdminRelationRepository(null);
            var result = Assert.ThrowsAsync<CenterAdminRelationsNotDeleteException>(async () => await centerAdminRelationRepository2.Delete(101));
            Assert.AreEqual("Error in deleting center admin relation details in database", result.Message);
        }
        [Test]
        public async Task GetAllSuccessTest()
        {
            var result = await centerAdminRelationRepository.GetAll();
            Assert.AreEqual(1, result.Count());
        }
        [Test]
        public async Task CenterAdminRelationsListNotFoundExceptionTest()
        {
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository2 = new CenterAdminRelationRepository(null);
            var result = Assert.ThrowsAsync<CenterAdminRelationsListNotFoundException>(async ()=>await  centerAdminRelationRepository2.GetAll());
            Assert.AreEqual("Error in getting center admin relation details list from database", result.Message);
        }
        [Test]
        public async Task UpdateSuccessTest()
        {
            CenterAdminRelation centerAdminRelation = new CenterAdminRelation()
            {

                Id = 101,
                CenterId = 101,
                UserId = 101,
            };
            var result = await centerAdminRelationRepository.Update(centerAdminRelation);
            Assert.AreEqual(result.Id, centerAdminRelation.Id);
        }
        [Test]
        public async Task CenterAdminRelationsNotFoundExceptionTest2()
        {
            CenterAdminRelation centerAdminRelation = new CenterAdminRelation()
            {

                Id = 1000,
                CenterId = 101,
                UserId = 104
            };
            var result = Assert.ThrowsAsync<CenterAdminRelationsNotFoundException>(async () => await centerAdminRelationRepository.Update(centerAdminRelation));
            Assert.AreEqual("Center admin relation details not found with id: 1000", result.Message);
        }
        [Test]
        public async Task CenterAdminRelationsNotUpdateExceptionTest()
        {
            IRepository<int, CenterAdminRelation> centerAdminRelationRepository2 = new CenterAdminRelationRepository(null);
            var result = Assert.ThrowsAsync<CenterAdminRelationsNotUpdateException>(async () => await centerAdminRelationRepository2.Update(null));
            Assert.AreEqual("Error in updating the center admin relation details in database", result.Message);
        }

    }
}
