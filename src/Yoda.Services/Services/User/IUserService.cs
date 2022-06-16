using Yoda.Services.Models;

namespace Yoda.Services.Services.User
{
    public interface IUserService
    {
        UserModel GetById(Guid userId);
        Guid Create(RegisterModel register);
        void Update(Guid userId, RegisterModel register);
    }
}
