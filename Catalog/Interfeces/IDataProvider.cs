using Catalog.Entityes;

namespace Catalog.Interfeces
{
    public interface IDataProvider
    {
        public Product[] GetAllProducts();
        public Product GetProduct(int id);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
    }
}