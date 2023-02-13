using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.DataAccess;
using MyFirstBackend.Helpers;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;
        public AccountController(JwtSettings jwtSettings, UniversityDBContext context)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var user = _context.Users.FirstOrDefault(user => user.Name.Equals(userLogin.UserName) && user.Password.Equals(userLogin.Password));

                if (user != null)
                {
                    

                    Token = JwtHelpers.GenTokenKey(
                        new UserTokens()
                        {
                            UserName = user.Name,
                            EmailId = user.Email,
                            Id = user.Id,
                            GuidId = Guid.NewGuid(),
                            Role = user.Role
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
            return Ok(_context.Users); 
        }
    

    }
}
