using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.OrderDetailsService
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly YodaContext _yodaContext;

        public OrderDetailsService(YodaContext yodacontext)
        {
            _yodaContext = yodacontext;
        }

        public int Create(OrderDetailModel orderDetail)
        {
            var order = new OrderDetailEntity()
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice,
            };
            _yodaContext.OrderDetails?.Add(order);
            _yodaContext.SaveChanges();
            return order.Id;
        }

        public void Delete(int id)
        {
            var result = _yodaContext.OrderDetails?.FirstOrDefault(order => order.Id == id);
            if (result != null)
            {
                _yodaContext.OrderDetails?.Remove(result);
                _yodaContext.SaveChanges();
            }
        }

        public OrderDetailModel GetById(int id)
        {
            var order = _yodaContext.OrderDetails?.AsNoTracking().FirstOrDefault(item => item.Id == id);
            if (order == null)
                return null;
            return new OrderDetailModel()
            {
                Id = order.Id,
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                UnitPrice = order.UnitPrice
            };
        }

        public IEnumerable<OrderDetailModel> GetList(int start = 0, int length = 10)
        {
            var result = _yodaContext.OrderDetails?.AsNoTracking().Skip(start).Take(length).ToList();
            if (result == null)
                return null;
            return _yodaContext.OrderDetails?.Select(item => new OrderDetailModel()
            {
                Id = item.Id,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            });
        }

        public void Update(int id, OrderDetailModel orderDetail)
        {
            var result = _yodaContext.OrderDetails?.FirstOrDefault(order => order.Id == id);
            if (result != null)
            {
                result.OrderId = orderDetail.OrderId;
                result.ProductId = orderDetail.ProductId;
                result.Quantity = orderDetail.Quantity;
                result.UnitPrice = orderDetail.UnitPrice;
                _yodaContext.SaveChanges();
            }
        }
    }
}
