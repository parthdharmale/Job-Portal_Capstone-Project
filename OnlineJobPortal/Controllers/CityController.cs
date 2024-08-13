using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await _cityRepository.GetAllCityAsync();
            return Ok(result);
        }

        [HttpGet("{CityID}")]
        public async Task<IActionResult> GetCityById(int CityID)
        {
            var result = await _cityRepository.GetCityByIdAsync(CityID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCity([FromBody] City city)
        {
            var id = await _cityRepository.AddCityAsync(city);

            if (id == -1)
            {
                return BadRequest();
            }

            //return CreatedAtAction(nameof(GetRecruiterById), new { id = id, controller = "Recruiter" }, id);
            return Ok("City Added");
        }

        [HttpPut("/city/{CityID}")]
        public async Task<IActionResult> UpdateCity([FromRoute] int CityID, [FromBody] City city)
        {
            await _cityRepository.UpdateCityByIDAsync(CityID, city);
            return Ok("Update Successful");
        }

        [HttpDelete("deleteCity/{CityID}")]
        public async Task<IActionResult> DeleteCity([FromRoute] int CityID)
        {
            await _cityRepository.DeleteCityByIDAsync(CityID);
            return Ok("Record Deleted Succesfully");
        }
    }
}
