using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()//возвращаем шаблон и отображаем на главной странице все товары, у которых isFavorite = true 
        {
            var homeCars = new HomeViewModel
            {
                favCars= _carRep.getFavCars
            };
            return View(homeCars);
        }
    }
}
