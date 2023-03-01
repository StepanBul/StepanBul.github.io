using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Data.Models
{
    public class ShopCart//модель отвечает за конзину
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }//выводит в корзину однотипный товар. Если он разный, то создается дополнительная корзина
        public List<ShopCartItem> listShopItems { get; set;}//список всех элементов, отображаемых в корзине

        public static ShopCart GetCart(IServiceProvider services)//функция позволяет добавлять новый товар, не теряя старый
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;//создаем новую сессию
            var context = services.GetRequiredService<AppDBContent >();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId",shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Car car)//функция позволяет добавлять товар в корзину
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car, 
                price = car.price
            }) ;

            appDBContent.SaveChanges();
        }
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
