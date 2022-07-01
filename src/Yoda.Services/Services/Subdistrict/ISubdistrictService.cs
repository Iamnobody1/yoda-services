using Yoda.Services.Models;

namespace Yoda.Services.Services.District;

public interface ISubDistrictService
{
    IEnumerable<SubDistrictModel> GetList(int id);
}
