using Yoda.Services.Models;

namespace Yoda.Services.Services.Subdistrict
{
    public interface ISubdistrictService
    {
        IEnumerable<SubDistrictModel> GetList(int id);
    }
}
