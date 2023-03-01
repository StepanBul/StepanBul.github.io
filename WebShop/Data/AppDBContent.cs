using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class AppDBContent : DbContext//класс, хранящий все настройки связанные с базами данных
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)//вызываем базовый конструктор по умолчанию
        {

        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }


    
}
