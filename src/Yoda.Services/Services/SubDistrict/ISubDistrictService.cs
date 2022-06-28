using Yoda.Services.Models;

namespace Yoda.Services.Services.SubDistrict
{
    public interface ISubDistrictService
    {
        IEnumerable<SubDistrictModel> GetList(int id);
    }
}
