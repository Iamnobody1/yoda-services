using Microsoft.AspNetCore.Mvc;

namespace Yoda.Services.Bun
{
    public class Greeting
    {
        public string Hello1()
        {
            return "hello";
        }

        public string Hello1(string message)
        {
            return "hello" + message;
        }
    }
}
