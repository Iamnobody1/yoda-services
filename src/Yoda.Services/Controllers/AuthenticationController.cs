using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Models;
using Yoda.Services.Services.Authentication;

namespace Yoda.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService LoginService;

        public AuthenticationController(ILoginService loginService)
        {
            LoginService = loginService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginModel login)
        {
            var result = LoginService.IsExist(login.Username, login.Password);
            if (result == null || result == Guid.Empty)
                return Unauthorized();
            return Ok(result);
        }
    }
}
