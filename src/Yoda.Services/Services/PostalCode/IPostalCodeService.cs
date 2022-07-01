using Yoda.Services.Models;

namespace Yoda.Services.Services.PostalCode
{
    public interface IPostalCodeService
    {
        IEnumerable<PostalCodeModel> GetList(int id);
    }
}
