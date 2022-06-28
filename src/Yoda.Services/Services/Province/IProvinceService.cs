using Yoda.Services.Models;
using Yoda.Services.Entities;
namespace Yoda.Services.Services.Province
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceByCountryModel> GetList(int id);
    }
}
