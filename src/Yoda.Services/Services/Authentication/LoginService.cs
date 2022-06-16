using Yoda.Services.Data;

namespace Yoda.Services.Services.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly YodaContext _yodaContext;

        public LoginService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public Guid? IsExist(string username, string password)
        {
            var user = _yodaContext.Users.FirstOrDefault(s => s.Username == username && s.Password == password);
            if (user == null)
                return null;
            return Guid.Parse(user.Id);
        }
    }
}
