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

        [HttpGet("")]
        public async Task<IActionResult> GetAllJobs()
        {
            var result = await _jobsRepository.GetAllJobsAsync();
            return Ok(result);
        }

        [HttpGet("{JobID}")]
        public async Task<IActionResult> GetJobById(int JobID)
        {
            var result = await _jobsRepository.GetJobByIdAsync(JobID);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            var id = await _jobsRepository.AddJobAsync(job);
            if(id == -1)
            {
                return BadRequest();
            }
            return Ok("Job Added");
        }

        [HttpPut("/job/{JobID}")]
        public async Task<IActionResult> UpdateJob([FromRoute] int JobID, [FromBody] Job job)
        {
            await _jobsRepository.UpdateJobByIDAsync(JobID, job);
            return Ok("Update Successful");
        }

        [HttpDelete("deleteJob/{JobID}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int JobID)
        {
            await _jobsRepository.DeleteJobByIDAsync(JobID);
            return Ok("Record Deleted Successfully");
        }

    }
}
