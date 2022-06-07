namespace Yoda.Services.Services.Authentication
{
    public class LoginService : ILoginService
    {
        public Guid? IsExist(string username, string password)
        {
            if (username == "admin" && password == "1234")
                return Guid.NewGuid();
            return null;
        }
    }
}
