using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.OrderDetail
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly YodaContext _yodaContext;

        public OrderDetailService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public OrderDetailModel GetById(int id)
        {
            var order = _yodaContext.OrderDetails.FirstOrDefault(orderdetail => orderdetail.Id == id);
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
            return _yodaContext.OrderDetails.Skip(start).Take(length).Select(order => new OrderDetailModel()
            {
                Id = order.Id,
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                UnitPrice = order.UnitPrice,
            });
        }

        public int Create(OrderDetailModel orderDetail)
        {
            var order = new OrderDetailEntity();
            order.OrderId = orderDetail.OrderId;
            order.ProductId = orderDetail.ProductId;
            order.Quantity = orderDetail.Quantity;
            order.UnitPrice = orderDetail.UnitPrice;
            _yodaContext.OrderDetails.Add(order);
            _yodaContext.SaveChanges();
            return order.Id;
        }
        public void Update(int id, OrderDetailEntity orderDetail)
        {
            var order = _yodaContext.OrderDetails.FirstOrDefault(orderdetail => orderdetail.Id == id);
            if (order != null)
            {
                order.OrderId = orderDetail.OrderId;
                order.ProductId = orderDetail.ProductId;
                order.Quantity = orderDetail.Quantity;
                order.UnitPrice = orderDetail.UnitPrice;
                _yodaContext.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var order = _yodaContext.OrderDetails.FirstOrDefault(orderdetail => orderdetail.Id == id);
            _yodaContext.OrderDetails.Remove(order);
            _yodaContext.SaveChanges();
        }
    }
}
