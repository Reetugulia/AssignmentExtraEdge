using AssignmentExtraEdge.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssignmentExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration configuration;
        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(new { token });
            }

            return NotFound("user not found");
        }

        // To generate token
        private string GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),

            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private Users Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(x => x.Email?.ToLower() ==
                userLogin.Email?.ToLower() && x.Password == userLogin?.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }


}
