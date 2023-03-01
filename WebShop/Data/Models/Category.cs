using System.Collections.Generic;

namespace WebShop.Data.Models
{
    public class Category//категория
    {
        public int id { get; set; }//уникальный идентификатор
        public string categoryname { get; set; }
        public string desc { get; set; }
        public List<Car> cars  { get; set; }//список необходим, чтобы в категории могло войти несколько автомобилей одной категории

    }
}
