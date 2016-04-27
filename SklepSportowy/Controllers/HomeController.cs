using Repository.Irepo;
using Repository.Models;
using SklepSportowy.Infrastructure;
using SklepSportowy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepSportowy.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepo _proRepo;

        private ICategoryRepo _catRepo;

        

        

        public HomeController(IProductRepo proRepo, ICategoryRepo catRepo)
        {
            _proRepo = proRepo;
            _catRepo = catRepo;
        }
        // GET: Home
        public ActionResult Index()
        {
            ICacheProvider cache = new DefaultCacheProvider();

            List<Product> NewArrivals;

            if (cache.IsSet(Const.NewItemCacheKey))
            {
                NewArrivals = cache.Get(Const.NewItemCacheKey) as List<Product>;
            }
            else
            {
                NewArrivals = _proRepo.LoadProducts().OrderBy(g => Guid.NewGuid()).Take(6).ToList();
                cache.Set(Const.NewItemCacheKey, NewArrivals, 30);
            }
            var categories = _catRepo.LoadCategories().ToList();

            var products = _proRepo.LoadProducts().OrderBy(g => Guid.NewGuid()).Take(6).ToList();

            var vm = new HomeViewModel()
            {
                Categories = categories,
                Products = products
            };

            return View(vm);
        }
    }
}