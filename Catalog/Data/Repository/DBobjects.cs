using Catalog.Data.Entityes;
using Catalog.Data.Infrostructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Catalog.Data.Repository
{
    public class DBobjects
    {
        public static void Initials(IApplicationBuilder app)
        {
            
            DataProviderDbContent content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<DataProviderDbContent>();
            
            if (!content.Products.Any())
            {
            }

            content.SaveChanges();
        }
     }
    }
}
