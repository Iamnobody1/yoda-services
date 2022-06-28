using Yoda.Services.Data;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly YodaContext _yodaContext;
        public CountryService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public IEnumerable<CountryModel> GetList(int id)
        {
            var items = _yodaContext.Countries
            .Select(country => new CountryModel()
            {
                Id = country.Id,
                Name = country.Name
            });
            return null;
        }
    }
}

