using Catalog.Data.Entityes;
using Catalog.Interfeces;

namespace Catalog.Servises
{
    public class ProductServis : IProductServise
    {
        private readonly IDataProvider _dataProvider;

        public ProductServis(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Product[] GetAll()
        {
            return _dataProvider.GetAllProducts();
        }

        public Product Get(int id)
        {
            return _dataProvider.GetProduct(id);
        }

        public void Create(Product product)
        {
            if (_dataProvider.GetProduct(product.Id) != null)
            {
                return;
            }

            _dataProvider.CreateProduct(product);
        }

        public void Update(Product product)
        {
            if (_dataProvider.GetProduct(product.Id) == null)
            {
                return;
            }

            _dataProvider.UpdateProduct(product);
        }

        public void Delete(int id)
        {
            _dataProvider.DeleteProduct(id);
        }
    }
}
