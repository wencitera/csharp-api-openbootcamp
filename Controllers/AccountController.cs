using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.Helpers;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<User> Logins = new List<User>
        {
            new User()
            {
                Id = 5,
                Email = "wencitera@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 6,
                Email = "pepe@gmail.com",
                Name = "User 1",
                Password = "pepe"
            },
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                
                if(Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(
                        new UserTokens()
                        {
                            UserName = user.Name,
                            EmailId = user.Email,
                            Id = user.Id,
                            GuidId = Guid.NewGuid(),
                        }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials");
                }
                return Ok(Token);
            }catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUsersList()
        {
            return Ok(Logins);
        }
    

    }
}
