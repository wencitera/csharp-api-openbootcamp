using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<AccountController> _stringLocalizer;
        private readonly ILogger<AccountController> _logger;

        public AccountController(JwtSettings jwtSettings, UniversityDBContext context, IStringLocalizer<AccountController> stringLocalizer, ILogger<AccountController> logger)
        {
            _jwtSettings = jwtSettings;
            _context = context;
            _stringLocalizer = stringLocalizer;
            _logger = logger;
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
                    return BadRequest(_stringLocalizer["WrongLoging"].Value);
                }
                return Ok(new { Msg = string.Format(_stringLocalizer["Welcome"].Value, Token.UserName), Token  });
            }catch (Exception ex)
            {
                throw new Exception(_stringLocalizer["TokenError"].Value, ex);
            }
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUsersList()
        {
            _logger.LogInformation("test");
            _logger.LogDebug("debug");
            _logger.LogWarning("warn");
            _logger.LogError("err");
            _logger.LogCritical("crit");
            return Ok(_context.Users); 
        }
    

    }
}
