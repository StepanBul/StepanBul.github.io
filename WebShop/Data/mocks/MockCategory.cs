using System.Collections.Generic;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories {
            get
            {
                return new List<Category>()
                {
                    new Category{ categoryname = "электромобили", desc = "Современный вид транспорта"},
                    new Category{ categoryname = "Классический автомобиль", desc = "Машины с двигателем внутреннего сгорания"}
                };
            }
        }
    }
}
