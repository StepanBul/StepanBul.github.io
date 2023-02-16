using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
    }
}
