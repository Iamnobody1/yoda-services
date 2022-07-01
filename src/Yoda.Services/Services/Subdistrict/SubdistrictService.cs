using Yoda.Services.Data;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Subdistrict
{
    public class SubdistrictService : ISubdistrictService
    {
        private readonly YodaContext _yodacontext;

        public SubdistrictService(YodaContext yodacontext)
        {
            _yodacontext = yodacontext;
        }

        public IEnumerable<SubDistrictModel> GetList(int id)
        {
            throw new NotImplementedException();
        }
    }
}
