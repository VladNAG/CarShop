using User.Data.Entityes;

namespace User.Interfeces
{
    public interface IServise
    {
        public Order[] GetAll();
        public void Save(Order order);
    }
}
