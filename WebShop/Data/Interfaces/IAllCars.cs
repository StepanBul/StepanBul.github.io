using System.Collections;
using System.Collections.Generic;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getObjectCar(int carId);
    }
}
