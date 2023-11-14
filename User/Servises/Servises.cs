using Microsoft.EntityFrameworkCore.Storage;
using User.Data.Entityes;
using User.Interfeces;

namespace User.Servises
{
    public class Servises : IServise
    {
        private readonly IDataProvider _dataProvider;
        public Servises(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Order[] GetAll()
        {
            return _dataProvider.GetAllOrders();
        }

        public void Save(Order order)
        {
            _dataProvider.SaveOrder(order);
        }
    }
}
