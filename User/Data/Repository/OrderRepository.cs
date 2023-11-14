using User.Data.Entityes;
using User.Interfeces;
using User.Data.Inforstructure;
using Microsoft.AspNetCore.Mvc;

namespace User.Data.Repository
{
    public class OrderRepository : IDataProvider
    {
        private readonly DataProviderDbContent _appDbContent;
        public OrderRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }

        public Order[] GetAllOrders()
        {
            return _appDbContent.Orders.ToArray();
        }

        public void SaveOrder(Order order)
        {
            _appDbContent.Add(order);
            _appDbContent.SaveChanges();
        }
    }
}
