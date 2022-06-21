using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Product
{
    public interface IProductService
    {
        int Create(ProductModel product);
        void Delete(int id);
        ProductModel GetById(int id);
        IEnumerable<ProductModel> GetList(int start = 0, int length = 10);
        void Update(int id, ProductModel product);
    }
}
