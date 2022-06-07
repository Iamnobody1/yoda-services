using Yoda.Services.Models;

namespace Yoda.Services.Services.User
{
    public class UserService : IUserService
    {
        public UserModel GetUserById(Guid userId)
        {
            return new UserModel
            {
                DisplayName = "DevCAT",
                Avatar = "https://thecatapi.com/api/images/get?format=src&type=gif"
            };
        }
    }
}
