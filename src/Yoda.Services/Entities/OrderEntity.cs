namespace Yoda.Services.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset CreateDateUTC { get; set; }
    }
}

