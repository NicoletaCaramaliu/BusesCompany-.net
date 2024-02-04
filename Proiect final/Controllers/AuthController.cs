using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proiect_final.Models;
using Proiect_final.Models.Enums;
using Proiect_final.Models.Users;
using Proiect_final.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Proiect_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMyName()
        {
            return Ok(_userService.GetMyName());
           //var userName = User?.Identity?.Name;
            //var roleClaims = User.FindAll(ClaimTypes.Role);
            //var roles = roleClaims?.Select(rc => rc.Value).ToList();
            //var roles2 = User?.Claims
              //  .Where(c => c.Type == ClaimTypes.Role)
                //.Select(c => c.Value)
              //  .ToList();
           // return Ok(new { userName, roles, roles2 });
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash =
                BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.Role = request.Role;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found.");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if(!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token");
            }
            else if(user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token has expired");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);


            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refredhToken = new RefreshToken 
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)
            };
            return refredhToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
