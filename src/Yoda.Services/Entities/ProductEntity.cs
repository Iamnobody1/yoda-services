namespace Yoda.Services.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<OrderDetailEntity> OrderDetails { get; set; }
}
