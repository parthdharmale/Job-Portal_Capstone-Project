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
        private readonly ILogger<CandidateController> _logger;
        public CandidateController(ICandidateRepository candidateRepository, ILogger<CandidateController> logger)
        {
            _candidateRepository = candidateRepository;
            _logger = logger;
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
                _logger.LogTrace("Result Not Found");
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
        [HttpPatch("UpdateCandidate/{CID}")]
        public async Task<IActionResult> UpdateCandidate([FromBody] JsonPatchDocument candidate, [FromRoute] int CID)
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

        [HttpPost("CheckCandidateCredentials")]
        public async Task<IActionResult> CheckCandidateCredentials([FromBody] CredentialsDto credentials)
        {
            if (credentials == null)
            {
                return BadRequest("Invalid credentials");
            }

            int candidateID = await _candidateRepository.CheckCandidateCredentialsAsync(credentials.Email, credentials.Password);

            if (candidateID > 0)
            {
                return Ok(new { Message = "Credentials are correct", CandidateId = candidateID });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
        }
    }
}
