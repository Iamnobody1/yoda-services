using Yoda.Services.Models;
using Yoda.Services.Entities;
namespace Yoda.Services.Services.Country
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetList(int id);
    }
}
