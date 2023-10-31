using Catalog.Entityes;
using Catalog.Interfeces;

namespace Catalog.Infrostructure
{
    public class DataProvider: IDataProvider
    {
        public List<Product> _data = new List<Product>();
        public Product[] GetAllProducts()
        {
            return _data.ToArray();
        }

        public Product GetProduct(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product)
        {
            _data.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _data.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Color = product.Color;
            }
        }

        public void DeleteProduct(int id)
        {
            var itemToDelete = _data.FirstOrDefault(p => p.Id == id);
            if (itemToDelete != null)
            {
                _data.Remove(itemToDelete);
            }
        }
    }
}
