using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Site.Data;
using Site.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Site.Services;
using System.Diagnostics;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher _passwordHasher;

        public UserController(ApplicationDbContext context, PasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid data.");

            try
            {
                if (await IsEmailAlreadyRegistered(user.Email))
                    return BadRequest(new { message = "Email-ul este deja înregistrat." });

                var emailDomain = user.Email.Split('@').Last();
                if (!await ValidateEmailDomain(emailDomain))
                {
                    return BadRequest(new { message = "Domeniul email-ului nu are înregistrări MX valide." });
                }

                user.Password = _passwordHasher.HashPassword(user.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "User registered successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "A apărut o eroare internă.", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        private async Task<bool> IsEmailAlreadyRegistered(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        private async Task<bool> ValidateEmailDomain(string domain)
        {
            try
            {
                var host = await Dns.GetHostEntryAsync(domain);
                return host.AddressList.Any(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser == null)
            {
                return BadRequest(new { message = "Email sau parolă incorectă." });
            }

            if(!_passwordHasher.VerifyPassword(existingUser.Password, user.Password))
            {
                return BadRequest(new { message = "Email sau parolă incorectă." });
            }

            return Ok(new { message = "Autentificare reușită!" });
        }
    
    }

    
}
