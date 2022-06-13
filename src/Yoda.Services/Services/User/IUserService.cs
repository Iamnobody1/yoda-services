using Yoda.Services.Models;

namespace Yoda.Services.Services.User
{
    public interface IUserService
    {
        UserModel GetUserById(Guid userId);
        Guid Create(RegisterModel register);
    }
}
