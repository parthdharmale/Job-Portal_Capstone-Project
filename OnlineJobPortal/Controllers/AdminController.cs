using JobPortalModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository, IConfiguration configuration)
        {
            _adminRepository = adminRepository;
            _configuration = configuration;
        }
        [Authorize]
        // GET: api/Admin
        [HttpGet("GetAdmins")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAllAdminAsync();
            return Ok(admins);
        }

        // GET: api/Admin/{id}
        [Authorize]

        [HttpGet("GetAdminByID/{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _adminRepository.GetAllAdminAsync();
            var result = admin.Find(a => a.AdminID == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Admin
        [HttpPost("AddAdmin")]
        [Authorize]

        public async Task<ActionResult<int>> AddAdmin(Admin admin)
        {
            var newAdminId = await _adminRepository.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdminById), new { id = newAdminId }, newAdminId);
        }

        // PUT: api/Admin/{id}
        [HttpPut("UpdateAdminByID/{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (id != admin.AdminID)
            {
                return BadRequest("Admin ID mismatch");
            }

            await _adminRepository.UpdateAdminByIDAsync(id, admin);
            return NoContent();
        }

        // DELETE: api/Admin/{id}
        [HttpDelete("DeleteAdminByID/{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminRepository.DeleteAdminByIDAsync(id);
            return NoContent();
        }

        [HttpPost("CheckAdminCredentials")]
        public async Task<IActionResult> CheckAdminCredentials([FromBody] CredentialsDto credentials)
        {
            if (credentials == null)
            {
                return BadRequest("Invalid credentials");
            }

            int adminID = await _adminRepository.CheckAdminCredentialsAsync(credentials.Email, credentials.Password);

            if (adminID > 0)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Username", credentials.Email.ToString()),
                    new Claim("Password", credentials.Password.ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenValue, User = credentials });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
        }
    }
}
