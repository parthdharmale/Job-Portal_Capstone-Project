using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal_xUnitTests;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;
using Moq;

namespace JobPortal_xUnitTests
{
    public class RecruiterRepository_Tests
    {

        private readonly RecruiterRepository _repository;
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public RecruiterRepository_Tests()
        {
            // Use an in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "OnlineJobPortalTestDB")
                .Options;

            // Seed data
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                context.Recruiters.AddRange(
                    new Recruiter { RID = 1, Name = "Alice", CityID = 1, Email = "alice@example.com", Contact = "1234567890" },
                    new Recruiter { RID = 2, Name = "Bob", CityID = 2, Email = "bob@example.com", Contact = "0987654321" }
                );
                context.SaveChanges();
            }

            // Create repository instance with the in-memory context
            _repository = new RecruiterRepository(new ApplicationDbContext(_dbContextOptions));
        }

        [Fact]
        public async Task GetAllRecruitersAsync_ShouldReturnAllRecruiters()
        {
            var result = await _repository.GetAllRecruitersAsync();

            Assert.Equal(2, result.Count);
            Assert.Contains(result, r => r.Name == "Alice");
            Assert.Contains(result, r => r.Name == "Bob");
        }

        [Fact]
        public async Task GetRecruiterByIdAsync_ShouldReturnCorrectRecruiter()
        {
            var result = await _repository.GetRecruiterByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Alice", result.Name);
        }

        [Fact]
        public async Task AddRecruiterAsync_ShouldAddRecruiter()
        {
            var newRecruiter = new Recruiter { RID = 5, Name = "Charlie", CityID = 3, Email = "charlie@example.com", Contact = "5555555555" };
            var newId = await _repository.AddRecruiterAsync(newRecruiter);

            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                var addedRecruiter = await context.Recruiters.FindAsync(newId);
                Assert.NotNull(addedRecruiter);
                Assert.Equal("Charlie", addedRecruiter.Name);
            }
        }

        [Fact]
        public async Task UpdateRecruiterByIDAsync_ShouldUpdateRecruiter()
        {
            var recruiterToUpdate = new Recruiter { Name = "Alice Updated", CityID = 1, Email = "aliceupdated@example.com", Contact = "1111111111" };
            await _repository.UpdateRecruiterByIDAsync(1, recruiterToUpdate);

            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                var updatedRecruiter = await context.Recruiters.FindAsync(1);
                Assert.Equal("Alice Updated", updatedRecruiter.Name);
                Assert.Equal("aliceupdated@example.com", updatedRecruiter.Email);
            }
        }

        [Fact]
        public async Task DeleteRecruiterByIDAsync_ShouldDeleteRecruiter()
        {
            await _repository.DeleteRecruiterByIDAsync(1);

            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                var deletedRecruiter = await context.Recruiters.FindAsync(1);
                Assert.Null(deletedRecruiter);
            }
        }
    }
}

//private readonly RecruiterRepository _recruiterRepository;
//private readonly ApplicationDbContext _context;
//public RecruiterRepository_Tests()
//{
//    //var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer()
//    _recruiterRepository = new RecruiterRepository(_context);
//}


//// Combined test to verify that GetUserById returns the correct user or null if not found
//[Theory]
//[InlineData(1, true)] // User with ID 1 exists
//[InlineData(99, false)] // User with ID 99 does not exist
//public async Task GetRecruiterById_ReturnsExpectedResult(int RID, bool userExists)
//{
//    // Act
//    var result = await _recruiterRepository.GetRecruiterByIdAsync(RID);
//    // Assert
//    if (userExists)
//    {
//        Assert.NotNull(result);
//        Assert.Equal(RID, result.RID);
//    }
//    else
//    {
//        Assert.Null(result);
//    }
//}
//[Fact]
//public async Task GetAllRecruitersAsync_ReturnsAllRecruiters()
//{
//    // Act
//    var result = await _recruiterRepository.GetAllRecruitersAsync();
//    // Assert
//    Assert.NotNull(result);
//    Assert.Equal(2, result.Count()); // Assuming there are 2 users initially
//}


//[Fact]
//public async Task AddRecruiterAsync_AddsRecruiterCorrectly()
//{
//    // Arrange
//    var newRecruiter = new Recruiter
//    {
//        RID = 1,
//        Name = "ORACLE",
//        CityID = 6,
//        Email = "oracle@india.com",
//        Contact = "1234567890"
//        //Add recruiter details
//    };
//    // Act
//    await _recruiterRepository.AddRecruiterAsync(newRecruiter);
//    var result = await _recruiterRepository.GetRecruiterByIdAsync(newRecruiter.RID);
//    // Assert
//    Assert.NotNull(result);
//    Assert.Equal(newRecruiter.RID, result.RID);
//    Assert.Equal(newRecruiter.Name, result.Name);
//    Assert.Equal(newRecruiter.Email, result.Email);
//}
//[Fact]
//public async Task UpdateRecruiterAsync_UpdatesRecruiterCorrectly()
//{
//    int RID = 1;
//    // Arrange
//    var updatedRecruiter = new Recruiter
//    {
//        RID = 1,
//        Name = "Parth",
//        CityID = 6,
//        Email = "parth@dharmale.com",
//        Contact = "1234567890"
//    };
//    // Act
//    await _recruiterRepository.UpdateRecruiterByIDAsync(RID, updatedRecruiter);
//    var result = await _recruiterRepository.GetRecruiterByIdAsync(updatedRecruiter.RID);
//    // Assert
//    Assert.NotNull(result);
//    Assert.Equal(updatedRecruiter.Name, result.Name);
//    Assert.Equal(updatedRecruiter.Email, result.Email);
//}
//[Fact]
//public async Task DeleteUserAsync_DeletesUserCorrectly()
//{
//    // Arrange
//    var RID = 1;
//    // Act
//    await _recruiterRepository.DeleteRecruiterByIDAsync(RID);
//    var result = await _recruiterRepository.GetRecruiterByIdAsync(RID);
//    // Assert
//    Assert.Null(result);
//}