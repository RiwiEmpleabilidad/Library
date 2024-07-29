using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Library.Data;
using Library.Models.DTOs;
using Library.App.Interfaces.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Library.Utils;

namespace Library.Controllers.AuthController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly IJwtService _jwtService;
        private readonly Bcrypt _bcrypt;

        public AuthController(BaseContext context, IJwtService jwtService, Bcrypt cbcrypt)
        {
            _context = context;
            _jwtService = jwtService;
            _bcrypt = cbcrypt;
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserDto user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Email and password are required.");
            }
            var User = await _context.users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (user.Email == User.Email && user.Password == User.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.Email),
                    new Claim(ClaimTypes.Role, "User")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
                return Ok();
            }

            BadRequest("Invalid");

            if (User == null )
            {
                return BadRequest("Please fill  all fields");
            }
            else
            {
                if (_bcrypt.VerifyPassword(user.Password, User.Password))
                {
                    var UserDto = new UserDto
                    {
                        Email = User.Email,
                        Password = User.Password
                    };
                    var token = _jwtService.GeneratedToken(UserDto);
                    return Ok(new { Token = token });
                }
            }

            return Unauthorized("Invalid credentials");
        }
    }
}