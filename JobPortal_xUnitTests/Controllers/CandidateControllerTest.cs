using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineJobPortal.Controllers;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_xUnitTests.Controllers
{
    public class CandidateControllerTest
    {
        private readonly CandidateController _candidateController;
        private readonly Mock<ICandidateRepository> _candidateRepositoryMock;

        public CandidateControllerTest()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateController = new CandidateController(_candidateRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllCandidates_ReturnsOkWithList()
        {
            var expectedOutput = new List<Candidate>()
            {
                new Candidate{  CID = 3,  FirstName = "ABC",  LastName = "DEF",  Email = "Pass@example.com",  Password = "Pass@11",  DOB = "1999-09-22",  Address = "Mumbai",  Contact = "9876543212",  CityID = 6,  StateID = 5,  CountryID = 4,  Education1 = "string",  EducationResult1 = 0,  EducationPassoutYear1 = "string",  Education2 = "string",  EducationResult2 = 0,  EducationPassoutYear2 = "string",  Education3 = "string",  EducationResult3 = 0,  EducationPassoutYear3 = "string",  Workex1 = "string",  WorkexDesc1 = "string",  Workex2 = "string",  WorkexDesc2 = "string",  Workex3 = "string",  WorkexDesc3 = "string",  City = null,  State = null,  Country = null, Applications = null}
            };

            _candidateRepositoryMock.Setup(service => service.GetAllCandidatesAsync()).ReturnsAsync(expectedOutput);

            var results = await _candidateController.GetAllCandidates() as OkObjectResult;

            Assert.NotNull(results);
            Assert.Equal(200, results.StatusCode);
            Assert.Equal(expectedOutput, results.Value);
        }

        [Fact]
        public async Task AddCandidate_Results_OkObject()
        {
            // Arrange
            var candidate = new Candidate { CID = 3, FirstName = "ABC", LastName = "DEF", Email = "Pass@example.com", Password = "Pass@11", DOB = "1999-09-22", Address = "Mumbai", Contact = "9876543212", CityID = 6, StateID = 5, CountryID = 4, Education1 = "string", EducationResult1 = 0, EducationPassoutYear1 = "string", Education2 = "string", EducationResult2 = 0, EducationPassoutYear2 = "string", Education3 = "string", EducationResult3 = 0, EducationPassoutYear3 = "string", Workex1 = "string", WorkexDesc1 = "string", Workex2 = "string", WorkexDesc2 = "string", Workex3 = "string", WorkexDesc3 = "string", City = null, State = null, Country = null, Applications = null };

            //Setup
            _candidateRepositoryMock.Setup(service => service.AddCandidateAsync(candidate)).ReturnsAsync(candidate.CID);

            //Act
            var result = await _candidateController.AddCandidate(candidate) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task AddCandidate_Returns_BadRequest()
        {
            // Arrange
            var candidate = new Candidate { LastName = "DEF", Email = "Pass@example.com", Password = "Pass@11", DOB = "1999-09-22", Address = "Mumbai", Contact = "9876543212", CityID = 6, StateID = 5, CountryID = 4, Education1 = "string", EducationResult1 = 0, EducationPassoutYear1 = "string", Education2 = "string", EducationResult2 = 0, EducationPassoutYear2 = "string", Education3 = "string", EducationResult3 = 0, EducationPassoutYear3 = "string", Workex1 = "string", WorkexDesc1 = "string", Workex2 = "string", WorkexDesc2 = "string", Workex3 = "string", WorkexDesc3 = "string", City = null, State = null, Country = null, Applications = null };

            //Setup
            _candidateRepositoryMock.Setup(service => service.AddCandidateAsync(candidate)).ReturnsAsync(candidate.CID);

            //Act
            var result = await _candidateController.AddCandidate(candidate) as OkObjectResult;

            Assert.Null(result);
        }

        //[Fact]
        //public async Task UpdateCandidate_Returns_OkObject()
        //{
        //    //Arrange
        //    var CID = 3;
        //JsonPatchDocument<Candidate> updatedCandidate = { operationType: 0, path: "string", op: "string", from: "string", value: "string" };

        //    // Setup
        //    _candidateRepositoryMock.Setup(service => service.UpdateCandidateByIDAsync(RID, updatedCandidate)).Returns(Task.CompletedTask);

        //    //Act
        //    var result = await _recruiterController.UpdateRecruiter(RID, updatedRecruiter) as OkObjectResult;

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(200, result.StatusCode);
        //}

        [Fact]
        public async Task DeleteRecruiter_ReturnsNothing()
        {
            var CID = 2;

            _candidateRepositoryMock.Setup(service => service.DeleteCandidateByIDAsync(CID)).Returns(Task.CompletedTask);

            var result = await _candidateController.DeleteCandidate(CID) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetCandidateByID_ReturnsOkObject()
        {
            var candidate = new Candidate { CID = 3, FirstName = "ABC", LastName = "DEF", Email = "Pass@example.com", Password = "Pass@11", DOB = "1999-09-22", Address = "Mumbai", Contact = "9876543212", CityID = 6, StateID = 5, CountryID = 4, Education1 = "string", EducationResult1 = 0, EducationPassoutYear1 = "string", Education2 = "string", EducationResult2 = 0, EducationPassoutYear2 = "string", Education3 = "string", EducationResult3 = 0, EducationPassoutYear3 = "string", Workex1 = "string", WorkexDesc1 = "string", Workex2 = "string", WorkexDesc2 = "string", Workex3 = "string", WorkexDesc3 = "string", City = null, State = null, Country = null, Applications = null };
            //Setup
            _candidateRepositoryMock.Setup(service => service.GetCandidateByIdAsync(3)).ReturnsAsync(candidate);

            //Act
            var result = await _candidateController.GetCandidateByID(3) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetCandidateByID_Returns_Null()
        {
            var candidate = new Candidate { CID = 3, FirstName = "ABC", LastName = "DEF", Email = "Pass@example.com", Password = "Pass@11", DOB = "1999-09-22", Address = "Mumbai", Contact = "9876543212", CityID = 6, StateID = 5, CountryID = 4, Education1 = "string", EducationResult1 = 0, EducationPassoutYear1 = "string", Education2 = "string", EducationResult2 = 0, EducationPassoutYear2 = "string", Education3 = "string", EducationResult3 = 0, EducationPassoutYear3 = "string", Workex1 = "string", WorkexDesc1 = "string", Workex2 = "string", WorkexDesc2 = "string", Workex3 = "string", WorkexDesc3 = "string", City = null, State = null, Country = null, Applications = null };
            //Setup
            _candidateRepositoryMock.Setup(service => service.GetCandidateByIdAsync(0)).ReturnsAsync(candidate);

            //Act
            var result = await _candidateController.GetCandidateByID(3) as OkObjectResult;

            Assert.Null(result);
        }
    }
}
