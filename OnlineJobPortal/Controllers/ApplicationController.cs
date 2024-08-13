using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllApplications()
        {
            var result = await _applicationRepository.GetAllApplicationsAsync();
            return Ok(result);
        }

        [HttpGet("{ApplicationID}")]
        public async Task<IActionResult> GetApplicationById(int ApplicationID)
        {
            var result = await _applicationRepository.GetApplicationByIdAsync(ApplicationID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddApplication([FromBody] Application application)
        {
            var id = await _applicationRepository.AddApplicationAsync(application);

            if (id == -1)
            {
                return BadRequest();
            }

            //return CreatedAtAction(nameof(GetRecruiterById), new { id = id, controller = "Recruiter" }, id);
            return Ok("Application Added");
        }

        [HttpPut("/application/{ApplicationID}")]
        public async Task<IActionResult> UpdateApplication([FromRoute] int ApplicationID, [FromBody] Application application)
        {
            await _applicationRepository.UpdateApplicationByIDAsync(ApplicationID, application);
            return Ok("Update Successful");
        }

        [HttpDelete("deleteApplication/{ApplicationID}")]
        public async Task<IActionResult> DeleteApplication([FromRoute] int ApplicationID)
        {
            await _applicationRepository.DeleteApplicationByIDAsync(ApplicationID);
            return Ok("Record Deleted Succesfully");
        }
    }
}
