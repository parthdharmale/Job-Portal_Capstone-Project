using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _countryRepository.GetAllCountryAsync();
            return Ok(result);
        }

        [HttpGet("{CountryID}")]
        public async Task<IActionResult> GetCountryById(int CountryID)
        {
            var result = await _countryRepository.GetCountryByIdAsync(CountryID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCountry([FromBody] Country country)
        {
            var id = await _countryRepository.AddCountryAsync(country);

            if (id == -1)
            {
                return BadRequest();
            }

            //return CreatedAtAction(nameof(GetRecruiterById), new { id = id, controller = "Recruiter" }, id);
            return Ok("Country Added");
        }

        [HttpPut("/country/{CountryID}")]
        public async Task<IActionResult> UpdateCountry([FromRoute] int CountryID, [FromBody] Country country)
        {
            await _countryRepository.UpdateCountryByIDAsync(CountryID, country);
            return Ok("Update Successful");
        }

        [HttpDelete("deleteCountry/{CountryID}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int CountryID)
        {
            await _countryRepository.DeleteCountryByIDAsync(CountryID);
            return Ok("Record Deleted Succesfully");
        }
    }
}
