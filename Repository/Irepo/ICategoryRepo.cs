using SklepSportowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy.Irepo
{
    public interface ICategoryRepo
    {
        IQueryable<Category> LoadCategories();
    }
}
