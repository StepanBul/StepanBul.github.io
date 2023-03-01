using System.Collections.Generic;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory//класс заменяющий MockCategory. Все данные вытягиваются из базы
    {
        private readonly AppDBContent appDBContent;//переменная нужна для работы с классом AppDBContent

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
