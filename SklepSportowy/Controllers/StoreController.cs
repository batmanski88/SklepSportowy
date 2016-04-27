using Repository.Irepo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SklepSportowy.Controllers
{
    public class StoreController : Controller
    {
        private IProductRepo _proRepo;
        private ICategoryRepo _catRepo;

        public StoreController(IProductRepo proRepo, ICategoryRepo catRepo)
        {
            _proRepo = proRepo;
            _catRepo = catRepo;
        }

        public ActionResult List(int categoryID)
        {
            ViewBag.CategoryID = categoryID;
            var products = _proRepo.LoadProducts().Where(p => p.CategoryID == categoryID).ToList();
            return View(products);
        }

        
        public ActionResult Menu()
        {
            var categories = _catRepo.LoadCategories().ToList();
            return PartialView(categories);
        }

        public ActionResult ProductsSuggestion(string term)
        {
            var products = this._proRepo.LoadProducts().Where(p => p.Name.ToLower().Contains(term.ToLower())).Take(5).Select(p => new { label = p.Name });

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}