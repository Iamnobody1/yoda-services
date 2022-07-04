using Yoda.Services.Models;

namespace Yoda.Services.Services.Province
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceByCountryModel> GetList(int id);
    }
}
