using Microsoft.AspNetCore.Mvc;

namespace Yoda.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public string Authentication(string Username, string Password)
        {
            Hello1();
            string 
            return "";
            // if (Username == "Fluke" && Password == "12345")
            // {
            //     return StatusCode(StatusCodes.Status200InternalServerError);
            // }
            // else
            // {

            //     return StatusCode(StatusCodes.Status500InternalServerError);
            // }
        }
    }
}
