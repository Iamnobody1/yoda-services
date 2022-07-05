namespace Yoda.Services.Customer.Models
{
    public class OrdersByCustomerIdModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderDetailByOrderIdModel> Orders { get; set; }
    }
}
