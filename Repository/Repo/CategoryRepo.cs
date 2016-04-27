using Repository.Irepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private ISportStoreContext _db;

        public CategoryRepo(ISportStoreContext db)
        {
            _db = db;
        }

        public IQueryable<Category> LoadCategories()
        {
            return _db.Categories;
        }
    }
}
