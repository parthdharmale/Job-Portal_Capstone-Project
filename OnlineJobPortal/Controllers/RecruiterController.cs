using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;
using static System.Reflection.Metadata.BlobBuilder;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {

        private readonly IRecruiterRepository _recruiterRepository;

        public RecruiterController(IRecruiterRepository recruiterRepository)
        {
            _recruiterRepository = recruiterRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllRecruiters()
        {
            var result = await _recruiterRepository.GetAllRecruitersAsync();
            return Ok(result);
        }

        [HttpGet("{RID}")]
        public async Task<IActionResult> GetRecruiterById(int RID)
        {
            var result = await _recruiterRepository.GetRecruiterByIdAsync(RID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddRecruiter([FromBody] Recruiter recruiter)
        {
            var id = await _recruiterRepository.AddRecruiterAsync(recruiter);

            if (id == -1)
            {
                return BadRequest();
            }

            //return CreatedAtAction(nameof(GetRecruiterById), new { id = id, controller = "Recruiter" }, id);
            return Ok("Recruiter Added");
        }

        [HttpPut("/recruiter/{RID}")]
        public async Task<IActionResult> UpdateRecruiter([FromRoute] int RID, [FromBody] Recruiter recruiter)
        {
            await _recruiterRepository.UpdateRecruiterByIDAsync(RID, recruiter);
            return Ok("Update Successful");
        }

        [HttpDelete("deleteRecruiter/{RID}")]
        public async Task<IActionResult> DeleteRecruiter([FromRoute] int RID)
        {
            await _recruiterRepository.DeleteRecruiterByIDAsync(RID);
            return Ok("Record Deleted Succesfully");
        }


    }
}
