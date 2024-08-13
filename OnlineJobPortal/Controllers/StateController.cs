using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStates()
        {
            var result = await _stateRepository.GetAllStateAsync();
            return Ok(result);
        }

        [HttpGet("{StateID}")]
        public async Task<IActionResult> GetStateById(int StateID)
        {
            var result = await _stateRepository.GetStateByIdAsync(StateID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddState([FromBody] State state)
        {
            var id = await _stateRepository.AddStateAsync(state);

            if (id == -1)
            {
                return BadRequest();
            }

            //return CreatedAtAction(nameof(GetRecruiterById), new { id = id, controller = "Recruiter" }, id);
            return Ok("State Added");
        }

        [HttpPut("/state/{StateID}")]
        public async Task<IActionResult> UpdateState([FromRoute] int StateID, [FromBody] State state)
        {
            await _stateRepository.UpdateStateByIDAsync(StateID, state);
            return Ok("Update Successful");
        }

        [HttpDelete("deleteState/{StateID}")]
        public async Task<IActionResult> DeleteState([FromRoute] int StateID)
        {
            await _stateRepository.DeleteStateByIDAsync(StateID);
            return Ok("Record Deleted Succesfully");
        }
    }
}
