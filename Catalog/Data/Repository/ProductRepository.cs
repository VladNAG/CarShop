using Catalog.Data.Infrostructure;
using Catalog.Data.Entityes;
using Catalog.Interfeces;

namespace Catalog.Data.Repository
{
    public class ProductRepository : IDataProvider
    {
        private readonly DataProviderDbContent _appDbContent;

        public ProductRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }

        public Product[] GetAllProducts()
        {
            return _appDbContent.Products.ToArray();
        }

        public Product GetProduct(int id)
        {
            return _appDbContent.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product)
        {
            _appDbContent.Add(product);
            _appDbContent.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _appDbContent.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Price = product.Price;
                existingProduct.img = product.img;
                existingProduct.shortDesc = product.shortDesc;
                existingProduct.longDesc = product.longDesc;

                _appDbContent.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var itemToDelete = _appDbContent.Products.FirstOrDefault(p => p.Id == id);
            if (itemToDelete != null)
            {
                _appDbContent.Products.Remove(itemToDelete);
                _appDbContent.SaveChanges();
            }
        }
    }
}
