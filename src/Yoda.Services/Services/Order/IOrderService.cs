using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Order;

public interface IOrderService
{
    IEnumerable<OrderModel> Get(int start = 0, int length = 10);
    OrderModel GetByID(int orderID);
    int Create(OrderModel newOrder);
    void Update(int orderId, OrderEntity newOrder);
    void Delete(int orderId);
}
