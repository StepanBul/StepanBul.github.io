using System.Collections;
using System.Collections.Generic;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }//возвращает весь товар
        IEnumerable<Car> getFavCars { get; }//возвращает избранные товары
        Car getObjectCar(int carId);//принимает id автомобиля
    }
}
