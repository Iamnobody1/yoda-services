using Yoda.Services.Data;

namespace Yoda.Services.Services.Authentication
{
    public class LoginService : ILoginService
    {
        public Guid? IsExist(string username, string password)
        {
            var userInfo = UserData.Infos?.FirstOrDefault(s => s.Username == username && s.Password == password);
            if (userInfo != null)
                return userInfo.ID;
            return null;
        }
    }
}
