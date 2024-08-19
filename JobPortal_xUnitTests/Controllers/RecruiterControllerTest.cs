using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Controllers;
using OnlineJobPortal.Data;
using OnlineJobPortal.Repository;
using Moq;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.AspNetCore.Mvc;
namespace JobPortal_xUnitTests.Controllers
{
    public class RecruiterControllerTest
    {
        private readonly RecruiterController _recruiterController;
        private readonly Mock<IRecruiterRepository> _recruiterRepositoryMock;

        public RecruiterControllerTest()
        {
            _recruiterRepositoryMock = new Mock<IRecruiterRepository>();
            _recruiterController = new RecruiterController(_recruiterRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllRecruiters_ReturnsOkWithListOfRecruiters()
        {
            var expectedOutput = new List<Recruiter>()
            {
                new Recruiter{RID = 1, Name = "Parth", CityID = 6, Email = "ABC@gmail.com", Contact = "1234567890"}
            };

            _recruiterRepositoryMock.Setup(service => service.GetAllRecruitersAsync()).ReturnsAsync(expectedOutput);

            var results = await _recruiterController.GetAllRecruiters() as OkObjectResult;

            Assert.NotNull(results);
            Assert.Equal(200, results.StatusCode);
            Assert.Equal(expectedOutput, results.Value);
        }

        [Fact]
        public async Task AddRecruiter_Results_OkObject()
        {
            // Arrange
            var recruiter = new Recruiter { RID = 2, Name = "JP Morgan Chase & Co.", CityID = 6, Email = "jpmc@usa.com", Contact = "1234567890" };

            //Setup
            _recruiterRepositoryMock.Setup(service => service.AddRecruiterAsync(recruiter)).ReturnsAsync(recruiter.RID);

            //Act
            var result = await _recruiterController.AddRecruiter(recruiter) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            //Assert.Equal("GetRecruiterByID", result.ActionName);
        }

        [Fact]
        public async Task UpdateRecruiter_Returns_OkObject()
        {
            //Arrange
            var updatedRecruiter = new Recruiter { RID = 2, Name = "Morningstar", CityID = 7, Email = "abc@gmail.com", Contact = "0987654321" };
            var RID = updatedRecruiter.RID;

            // Setup
            _recruiterRepositoryMock.Setup(service => service.UpdateRecruiterByIDAsync(RID, updatedRecruiter)).Returns(Task.CompletedTask);

            //Act
            var result = await _recruiterController.UpdateRecruiter(RID, updatedRecruiter) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]

        public async Task DeleteRecruiter_ReturnsNothing()
        {
            var RID = 2;

            _recruiterRepositoryMock.Setup(service => service.DeleteRecruiterByIDAsync(RID)).Returns(Task.CompletedTask);

            var result = await _recruiterController.DeleteRecruiter(RID) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetRecruiterByID_ReturnsOkObject()
        {
            var updatedRecruiter = new Recruiter { RID = 2, Name = "Morningstar", CityID = 7, Email = "abc@gmail.com", Contact = "0987654321" };
            int RID = updatedRecruiter.RID;
            //Setup
            _recruiterRepositoryMock.Setup(service => service.GetRecruiterByIdAsync(RID)).ReturnsAsync(updatedRecruiter);

            //Act
            var result = await _recruiterController.GetRecruiterById(RID) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
