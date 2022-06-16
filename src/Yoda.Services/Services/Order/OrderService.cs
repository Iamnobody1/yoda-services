using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Order;

public class OrderService : IOrderService
{
    private readonly YodaContext _yodaContext;

    public OrderService(YodaContext yodaContext)
    {
        _yodaContext = yodaContext;
    }

    public IEnumerable<OrderModel> Get(int start = 0, int length = 10)
    {
        var items = _yodaContext.Orders.Skip(start).Take(length).Select(item => new OrderModel()
        {
            Id = item.Id,
            CustomerId = item.CustomerId,
            CreateDateUTC = item.CreateDateUTC
        });
        if (items == null)
            return null;
        return items;
    }

    public OrderModel GetById(int orderId)
    {
        var item = _yodaContext.Orders.FirstOrDefault(x => x.Id == orderId);
        if (item == null)
            return null;
        return new OrderModel()
        {
            Id = item.Id,
            CustomerId = item.CustomerId,
            CreateDateUTC = item.CreateDateUTC
        };
    }

    public int Create(OrderModel newOrder)
    {
        var order = new OrderEntity();
        order.CustomerId = newOrder.CustomerId;
        order.CreateDateUTC = new DateTimeOffset(DateTime.Now).ToUniversalTime();
        _yodaContext.Orders.Add(order);
        _yodaContext.SaveChanges();
        return order.Id;
    }

    public void Update(int orderId, OrderEntity newOrder)
    {
        var order = _yodaContext.Orders.FirstOrDefault(s => s.Id == orderId);
        if (order != null)
        {
            order.CustomerId = newOrder.CustomerId;
            _yodaContext.Orders.Update(order);
            _yodaContext.SaveChanges();
        }
    }

    public void Delete(int orderId)
    {
        var order = _yodaContext.Orders.FirstOrDefault(s => s.Id == orderId);
        if (order != null)
        {
            _yodaContext.Orders.Remove(order);
            _yodaContext.SaveChanges();
        }
    }
}
