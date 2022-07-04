using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Models;

namespace Yoda.Services.Services.PostalCode
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly YodaContext _yodaContext;

        public PostalCodeService(YodaContext yodaContext)
        {
            yodaContext = _yodaContext;
        }
        public IEnumerable<PostalCodeModel> GetList(int id)
        {
            return _yodaContext
            .PostalCodes
            .AsNoTracking()
            .Where(pos => pos.DistrictId == id && pos.EnabledFlag == true)
            .Select(postal => new PostalCodeModel()
            {
                Id = postal.Id,
                PostCode = postal.PostCode
            });
        }
    }
}
