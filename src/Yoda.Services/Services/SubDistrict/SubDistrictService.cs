using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Models;

namespace Yoda.Services.Services.District;

public class SubDistrictService : ISubDistrictService
{
    private readonly YodaContext _yodaContext;

    public SubDistrictService(YodaContext yodaContext)
    {
        _yodaContext = yodaContext;
    }

    public IEnumerable<SubDistrictModel> GetList(int id)
    {
        return _yodaContext.SubDistricts
        .AsNoTracking()
        .Where(item => item.EnabledFlag == true && item.DistrictId == id)
        .Select(dis => new SubDistrictModel()
        {
            Id = dis.Id,
            Name = dis.Name,
        });
    }
}
