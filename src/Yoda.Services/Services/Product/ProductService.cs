using Yoda.Service2.Data;
using Yoda.Service2.Entities;
using Yoda.Service2.Models;
using Microsoft.EntityFrameworkCore;

namespace Yoda.Service2.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly YodaContext _DataContext;

        public ProductService(YodaContext DataContext)
        {
            _DataContext = DataContext;
        }

        public ProductModel GetById(int id)
        {
            var item = _DataContext.Products?.AsNoTracking().FirstOrDefault(item => item.Id == id);
            if (item == null)
                return null;
            return new ProductModel()
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public IEnumerable<ProductModel> GetList(int start = 0, int length = 10)
        {
            return _DataContext.Products.AsNoTracking().Skip(start).Take(length).Select(Product => new ProductModel()
            {
                Id = Product.Id,
                Name = Product.Name
            });
        }

        public int Create(ProductModel product)
        {
            var item = new ProductEntity();
            item.Name = product.Name;
            _DataContext.Products.Add(item);
            _DataContext.SaveChanges();
            return item.Id;
        }

        public void Delete(int id)
        {
            var item = _DataContext.Products.FirstOrDefault(Product => Product.Id == id);
            _DataContext.Products.Remove(item);
            _DataContext.SaveChanges();
        }

        public void Update(int id, ProductModel product)
        {
            var item = _DataContext.Products.FirstOrDefault(product => product.Id == id);
            if (item != null)
            {
                item.Name = product.Name;
                _DataContext.SaveChanges();
            }
        }
    }
}
