using Yoda.Services.Models;

namespace Yoda.Services.Services.District;

public interface IDistrictService
{
    IEnumerable<DisWithPosAndSubModel> GetByProvinceId(int id);
    IEnumerable<DistrictModel> GetList(int id);
}
