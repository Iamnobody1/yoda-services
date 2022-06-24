namespace Yoda.Services.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset CreateDateUTC { get; set; }

        public CustomerEntity Customer { get; set; }
        public List<OrderDetailEntity> OrderDetail { get; set; }
    }
}
