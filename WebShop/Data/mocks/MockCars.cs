using System.Collections.Generic;
using System.Linq;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.mocks
{
    public class MockCars : IAllCars
    {

        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car {
                        name = "Tesla",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/tesla-s.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First() },
                    new Car {
                        name = "BMW",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/bmw.jpg",
                        price = 10000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First() },
                };
            }

        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
