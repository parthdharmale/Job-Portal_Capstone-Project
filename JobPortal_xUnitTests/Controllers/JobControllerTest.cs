using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineJobPortal.Controllers;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_xUnitTests.Controllers
{
    public class JobControllerTest
    {
        private readonly JobController _jobController;
        private readonly Mock<IJobsRepository> _jobRepositoryMock;
        public JobControllerTest()
        {
            _jobRepositoryMock = new Mock<IJobsRepository>();
            _jobController = new JobController(_jobRepositoryMock.Object);
        }
        [Fact]
        public async Task GetAllJobs_ReturnsOkWithListOfJobs()
        {
            var expectedOutput = new List<Job>()
            {
                new Job{ JobID = 1, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" }
            };
            _jobRepositoryMock.Setup(service => service.GetAllJobsAsync()).ReturnsAsync(expectedOutput);
            var results = await _jobController.GetAllJobs() as OkObjectResult;
            Assert.NotNull(results);
            Assert.Equal(200, results.StatusCode);
            Assert.Equal(expectedOutput, results.Value);
        }
        [Fact]
        public async Task AddJob_Results_OkObject()
        {
            // Arrange
            var job = new Job{ JobID = 1, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            //Setup
            _jobRepositoryMock.Setup(service => service.AddJobAsync(job)).ReturnsAsync(job.JobID);
            //Act
            var result = await _jobController.AddJob(job) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            //Assert.Equal("GetRecruiterByID", result.ActionName);
        }

        [Fact]
        public async Task UpdateJob_Returns_OkObject()
        {
            //Arrange
            var updatedJobs = new Job{ JobID = 1, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            string update = "Updated";
            // Setup
            _jobRepositoryMock.Setup(service => service.AddJobAsync(updatedJobs));
            //Act
            var result = await _jobController.UpdateJob(updatedJobs.JobID, updatedJobs) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task DeleteJob_ReturnsNothing()
        {
            var jobID = 2;
            _jobRepositoryMock.Setup(service => service.DeleteJobByIDAsync(jobID));
            var result = await _jobController.DeleteJob(jobID) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetJobsByID_ReturnsJob()
        {
            var updatedJob = new Job { JobID = 1, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            int jobID = updatedJob.JobID;
            //Setup
            _jobRepositoryMock.Setup(service => service.GetJobByIdAsync(jobID)).ReturnsAsync(updatedJob);
            //Act
            var result = await _jobController.GetJobById(jobID) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetJobsByRID_ReturnsJob()
        {
            var updatedJob = new Job { JobID = 1, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            int RID = updatedJob.RID;
            //Setup
            _jobRepositoryMock.Setup(service => service.GetJobByRecruiterIdAsync(RID)).ReturnsAsync(updatedJob);
            //Act
            var result = await _jobController.GetJobByRecruiterId(RID) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetJobsByName_ReturnsJob()
        {
            var updatedJob = new Job { JobID = 1, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            string jobName = updatedJob.Description;
            //Setup
            _jobRepositoryMock.Setup(service => service.GetJobByNameAsync(jobName)).ReturnsAsync(updatedJob);
            //Act
            var result = await _jobController.GetJobByName(jobName) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetJobsByID_ReturnsNull()
        {
            var updatedJob = new Job { JobID = 0, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            int jobID = 0;
            //Setup
            _jobRepositoryMock.Setup(service => service.GetJobByIdAsync(jobID)).ReturnsAsync(updatedJob);
            //Act
            var result = await _jobController.GetJobById(jobID) as OkObjectResult;
            Assert.Null(result);
            //Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public async Task GetJobsByRID_ReturnsNull()
        {
            var updatedJob = new Job { JobID = 0, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            int RID = updatedJob.RID;
            //Setup
            _jobRepositoryMock.Setup(service => service.GetJobByRecruiterIdAsync(RID)).ReturnsAsync(updatedJob);
            //Act
            var result = await _jobController.GetJobByRecruiterId(RID) as OkObjectResult;
            Assert.Null(result);
            //Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public async Task GetJobsByName_ReturnsNull()
        {
            var updatedJob = new Job { JobID = 0, RID = 101, CityID = 501, Location = "New York, NY", Description = "Software Engineer", Skills = "C#, ASP.NET Core, SQL Server, JavaScript", RecruiterName = "John Doe", RecruiterContact = "+1-555-123-4567", RecruiterEmail = "johndoe@example.com", JobPostDate = DateTime.Now, JobExpireDate = DateTime.Now.AddMonths(1), ModeOfWork = "Remote" };
            string jobName = "";
            //Setup
            _jobRepositoryMock.Setup(service => service.GetJobByNameAsync(jobName)).ReturnsAsync(updatedJob);
            //Act
            var result = await _jobController.GetJobByName(jobName) as OkObjectResult;
            Assert.Null(result);
            //Assert.Equal(404, result.StatusCode);
        }
    }
}
