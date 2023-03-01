using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat) //конструктор
        {
            _allCars = iAllCars;//помимо интерфейса обращаемся еще и к классу, который реализует интерфейс блягодаря скрипту Startup
            _allCategories = iCarsCat;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]

        public ViewResult List(string category)//возвращает html страничку
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))//выводит все электромобили
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryname.Equals("электромобили")).OrderBy(i => i.id);
                    currCategory = "электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))//выводит все бензиновые автомобили
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryname.Equals("Классический автомобиль")).OrderBy(i => i.id);
                    currCategory = "Классический автомобиль";
                }

            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currCategory

            };

            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }
    }
}
