using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobsRepository _jobsRepository;
        public JobController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }
        [HttpGet("GetAllJobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            var result = await _jobsRepository.GetAllJobsAsync();
            return Ok(result);
        }
        [HttpGet("GetJobByID/{JobID}")]
        public async Task<IActionResult> GetJobById(int JobID)
        {
            var result = await _jobsRepository.GetJobByIdAsync(JobID);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetJobByName/{jobName}")]
        public async Task<IActionResult> GetJobByName(string jobName)
        {
            var result = await _jobsRepository.GetJobByNameAsync(jobName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetJobByRecruiterID/{rID}")]
        public async Task<IActionResult> GetJobByRecruiterId(int rID)
        {
            var result = await _jobsRepository.GetJobByRecruiterIdAsync(rID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("AddJob")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            var id = await _jobsRepository.AddJobAsync(job);
            if(id <= 0)
            {
                return BadRequest();
            }
            return Ok("Job Added");
        }
        [HttpPut("UpdateJob/{JobID}")]
        public async Task<IActionResult> UpdateJob([FromRoute] int JobID, [FromBody] Job job)
        {
            await _jobsRepository.UpdateJobByIDAsync(JobID, job);
            return Ok("Update Successful");
        }
        [HttpDelete("DeleteJob/{JobID}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int JobID)
        {
            await _jobsRepository.DeleteJobByIDAsync(JobID);
            return Ok("Record Deleted Successfully");
        }
    }
}
