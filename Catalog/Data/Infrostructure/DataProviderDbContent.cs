using Catalog.Data.Entityes;
using Catalog.Data.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Infrostructure
{
    public class DataProviderDbContent : DbContext
    {
        public DataProviderDbContent(DbContextOptions<DataProviderDbContent> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        
    }
}
