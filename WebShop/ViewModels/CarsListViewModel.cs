using System.Collections.Generic;
using WebShop.Data.Models;

namespace WebShop.ViewModels
{
    public class CarsListViewModel//
    {
        public IEnumerable<Car> allCars { get; set; }//все автомобили
        public string currCategory { get; set; }//категория с который мы сейчас работаем
    }
}
