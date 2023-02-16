using System.Collections;
using System.Collections.Generic;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
