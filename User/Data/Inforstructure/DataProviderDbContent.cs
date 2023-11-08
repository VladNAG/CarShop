using Microsoft.EntityFrameworkCore;
using User.Data.Entityes;

namespace User.Data.Inforstructure
{
    public class DataProviderDbContent : DbContext
    {
        public DataProviderDbContent(DbContextOptions<DataProviderDbContent> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
    }
}
