using Yoda.Services.Data;

using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly YodaContext _yodaContext;

        public CustomerService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }


        public int Create(CustomerModel customer)
        {
            var cus = new CustomerEntity();
            cus.Name = customer.Name;
            _yodaContext.Customers.Add(cus);
            _yodaContext.SaveChanges();
            return cus.Id;
        }

        public CustomerModel GetById(int id)
        {
            var item = _yodaContext.Customers.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return null;
            }
            return new CustomerModel() { Id = item.Id, Name = item.Name };
        }

        public IEnumerable<CustomerModel> GetList(int start = 0, int lenght = 2)
        {
            var item = _yodaContext.Customers.Skip(start).Take(lenght).Select(item => new CustomerModel() { Id = item.Id, Name = item.Name });
            return item;
        }

        public void Update(int id, CustomerEntity cus)
        {
            var item = _yodaContext.Customers.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                item.Name = cus.Name;
                _yodaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _yodaContext.Customers.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                _yodaContext.Customers.Remove(item);
                _yodaContext.SaveChanges();
            }
        }
    }
}
