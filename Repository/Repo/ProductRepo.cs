using SklepSportowy.Irepo;
using SklepSportowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy.Repo
{
    public class ProductRepo: IProductRepo
    {
        private ISportStoreContext _db;

        public ProductRepo(ISportStoreContext db)
        {
            _db = db;
        }

        public IQueryable<Product> LoadProducts()
        {
          return  _db.Products;
        }

       
    }
}
