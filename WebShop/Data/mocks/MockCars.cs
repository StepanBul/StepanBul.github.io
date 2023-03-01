using System.Collections.Generic;
using System.Linq;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.mocks
{
    public class MockCars : IAllCars//класс реализует интерфейс IAllCars
    {

        private readonly ICarsCategory _categoryCars = new MockCategory();//переменная указывает к какой категории относится объект(автомобиль)

        public IEnumerable<Car> Cars //реализуем функцию Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car {
                        name = "Tesla",
                        shortDesc = "Бесшумный",
                        longDesc = "Совсем нет шума",
                        img = "/img/tesla-s.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First() },
                    new Car {
                        name = "BMW",
                        shortDesc = "Быстрый",
                        longDesc = "ОООООчень быстрый",
                        img = "/img/bmw.jpg",
                        price = 10000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last() },
                };
            }

        }
        public IEnumerable<Car> getFavCars { get; }

        public Car getObjectCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
