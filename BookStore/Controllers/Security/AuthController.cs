using BookStore.Data.Security;
using BookStore.Models.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers.Security
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        private List<User> _users = new List<User>
        {
            new User{ Id=1, Name="TestName1" , Surname="TestSurname1", Email="TestEmail1", Username="string1", Password="string1"},
            new User{ Id=2, Name="TestName2" , Surname="TestSurname2", Email="TestEmail2", Username="TestUsername2", Password="TestPassword2"}
        };

        [HttpPost]
        public ActionResult<LoginResultModel> Login(LoginModel model)
        {
            var user = _users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            if (user == null)
            {
                return NotFound(new
                {
                    message = "Username or password is not correct"
                });
            }
            var token = GenerateJwtToken(user);
            return Ok(new LoginResultModel
            {
                UserId = user.Id,
                AuthToken = token
            });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SigningKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                }),
                Issuer ="example.com",
                Audience = "example.com",
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
