using Microsoft.AspNetCore.Mvc;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    public string Authentication(string Username, string Password)
    {
        if (Username == "Fluke" && Password == "12345") {
            return"200";
         }

        else{
            return"401";
         }



    }
}
