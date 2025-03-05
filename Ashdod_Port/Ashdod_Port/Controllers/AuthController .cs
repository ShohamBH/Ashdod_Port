using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;

namespace Ashdod_Port.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // הוסף את רשימת המשתמשים כאן
        private List<User> _users = new List<User>
        {
            new User { UserName = "testUser", Password = "testPassword" }
        };

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (ValidateUser(request.UserName, request.Password))
            {
                var token = GenerateToken(request.UserName);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [HttpGet]
        public ActionResult Registration(string userName, string password)
        {
            // שמור את המשתמש בבסיס הנתונים
            var token = GenerateToken(userName);
            return Ok(token);
        }

        [Authorize]
        [HttpGet("RefreshToken")]
        public IActionResult RefreshToken(string userLogin)
        {
            var token = GenerateToken(userLogin);
            return Ok(token);
        }

        private string GenerateToken(string userName)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool ValidateUser(string username, string password)
        {
            // בדוק אם המשתמש קיים ברשימה
            var user = _users.SingleOrDefault(u => u.UserName == username && u.Password == password);
            return user != null; // יחזור true אם נמצא, false אם לא
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class User // הוסף מחלקת משתמש אם עדיין לא קיימת
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Ashdod_Port.Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;

//        public AuthController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpGet]
//        public ActionResult Registration(string userName, string password)
//        {
//            //save user in DB

//            //Generate token
//            var token = GenerateToken(userName);
//            return Ok(token);
//        }

//        [Authorize]
//        [HttpGet("RefreshToken")]
//        public IActionResult RefreshToken(string userLogin)
//        {

//            var token = GenerateToken(userLogin);
//            return Ok(token);
//        }

//        private string GenerateToken(string userName)
//        {
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, userName)
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.Now.AddSeconds(20),
//                signingCredentials: creds);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//    }

//}