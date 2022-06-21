namespace Yoda.Services.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OrderEntity> Orders { get; set; }
    }
}
