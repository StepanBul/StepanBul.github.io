using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/tesla-s.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["электромобили"]
                    },
                    new Car
                    {
                        name = "BMW",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/bmw.jpg",
                        price = 10000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Классический автомобиль"]
                    }
                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryname = "электромобили", desc = "Современный вид транспорта" },
                        new Category { categoryname = "Классический автомобиль", desc = "Машины с двигателем внутреннего сгорания" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.categoryname, el);
                    }
                    
                }
                return category;
            }


        }
    }
}
   

