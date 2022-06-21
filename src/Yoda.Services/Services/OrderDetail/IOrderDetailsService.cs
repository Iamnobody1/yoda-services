using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.OrderDetail
{
    public interface IOrderDetailService
    {
        OrderDetailModel GetById(int orderId);
        IEnumerable<OrderDetailModel> GetList(int start = 0, int length = 10);
        int Create(OrderDetailModel orderDetail);
        void Update(int orderId, OrderDetailEntity orderDetail);
        void Delete(int orderId);
    }
}
