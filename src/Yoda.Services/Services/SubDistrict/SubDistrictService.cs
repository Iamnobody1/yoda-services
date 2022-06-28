using Yoda.Services.Data;
using Yoda.Services.Models;

namespace Yoda.Services.Services.SubDistrict
{
    public class SubDistrictService : ISubDistrictService
    {
        private readonly YodaContext _yodaContext;
        public SubDistrictService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public IEnumerable<SubDistrictModel> GetList(int id)
        {
            var items = _yodaContext.SubDistricts
            .Where(item => item.District.Id == id)
            .Select(subDistrict => new SubDistrictModel()
            {
                Id = subDistrict.Id,
                Name = subDistrict.Name
            });
            return items;
        }
    }
}

