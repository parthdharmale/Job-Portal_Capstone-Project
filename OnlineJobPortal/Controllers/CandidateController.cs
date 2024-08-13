using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet("GetAllCandidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            var result = await _candidateRepository.GetAllCandidatesAsync();
            return Ok(result);
        }

        [HttpGet("GetCandidateByID/{CID}")]
        public async Task<IActionResult> GetCandidateByID(int CID)
        {
            var result = await _candidateRepository.GetCandidateByIdAsync(CID);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("AddCandidate")]
        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidate)
        {
            var id = await _candidateRepository.AddCandidateAsync(candidate);

            if(id == -1)
            {
                return BadRequest();
            }

            return Ok("Candidate Added");
        }
        [HttpPut("/UpdateCandidate/{CID}")]
        public async Task<IActionResult> UpdateCandidate([FromRoute] int CID, [FromBody] JsonPatchDocument candidate)
        {
            await _candidateRepository.UpdateCandidateByIDAsync(CID, candidate);
            return Ok("Update SAuccesful");
        }
        [HttpDelete("DeleteCandidate/{CID}")]
        public async Task<IActionResult> DeleteCandidate([FromRoute] int CID)
        {
            await _candidateRepository.DeleteCandidateByIDAsync(CID);
            return Ok("Record Deleted Succesfully");
        }
    }
}
