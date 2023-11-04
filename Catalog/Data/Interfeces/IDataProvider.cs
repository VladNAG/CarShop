using Catalog.Data.Entityes;

namespace Catalog.Data.Interfeces
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