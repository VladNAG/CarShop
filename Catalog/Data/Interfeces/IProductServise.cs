using Catalog.Data.Entityes;

namespace Catalog.Data.Interfeces
{
    public interface IProductServise
    {
        public Product[] GetAll();

        public Product Get(int id);

        public void Create(Product product);

        public void Update(Product product);

        public void Delete(int id);
    }
}
