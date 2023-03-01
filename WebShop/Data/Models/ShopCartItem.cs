namespace WebShop.Data.Models
{
    public class ShopCartItem//отвечает за товары в корзине
    {
        public int id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }
        public string ShopCartId { get; set; }
    }
}
