using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Order;

public interface IOrderService
{
    IEnumerable<OrderModel> Get(int start = 0, int length = 10);
    OrderModel GetById(int orderId);
    int Create(OrderModel newOrder);
    void Update(int orderId, OrderEntity newOrder);
    void Delete(int orderId);
}
