namespace Yoda.Services.Services.Authentication
{
    public interface ILoginService
    {
        Guid? IsExist(string username, string password);
    }
}
