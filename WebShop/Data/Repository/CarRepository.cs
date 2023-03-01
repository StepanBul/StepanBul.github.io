using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class CarRepository : IAllCars//класс заменяющий MockCars. Все данные вытягиваются из базы
    {
        private readonly AppDBContent appDBContent;//переменная нужна для работы с классом AppDBContent

        public CarRepository(AppDBContent appDBContent)//конструктор по умолчанию
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);//получаем данные с AppDBContent(с базы данных)

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavorite).Include(c => c.Category);//Для выбора элементов из некоторого набора по условию используется метод Where:

        public Car getObjectCar(int carid) => appDBContent.Car.FirstOrDefault(p => p.id == carid);//получает id машины
    }
}
