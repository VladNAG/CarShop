using User.Data.Entityes;

namespace User.Interfeces
{
    public interface IDataProvider
    {
        public Order[] GetAllOrders();
        public void SaveOrder(Order order);
    }
}
