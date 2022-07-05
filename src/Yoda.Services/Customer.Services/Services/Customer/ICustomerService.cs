using Yoda.Services.Models;
using Yoda.Services.Entities;
namespace Yoda.Services.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetList(int start = 0, int lenght = 2);
        int Create(CustomerModel customer);
        CustomerModel GetById(int customerId);
        void Update(int id, CustomerEntity cus);
        void Delete(int id);

    }
}
