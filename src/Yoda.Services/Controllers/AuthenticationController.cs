using Microsoft.AspNetCore.Mvc;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    [EnableCors("AnotherPolicy")]
    [HttpGet]
    public string Authentication(string Username, string Password)
    {
        if (Username == "Fluke" && Password == "12345") {
            return StatusCode(StatusCodes.Status200InternalServerError);
         }

        else{
            
            return StatusCode(StatusCodes.Status500InternalServerError);
         }



    }
}
