
using SklepSportowy.Models;
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
        private SportStoreContext _db;

        public StoreController(SportStoreContext db)
        {
            _db = db;
        }

        public ActionResult List(string currentCategory, string searchQuery = null)
        {
            var category = _db.Categories.Include("Products").Where(g => g.Name.ToUpper() == currentCategory.ToUpper()).Single();
            var products = category.Products.Where(p => (searchQuery == null || p.Name.ToLower().Contains(searchQuery.ToLower()))).ToList();

            if(Request.IsAjaxRequest())
            {
                return PartialView("ProductList", products);
            }
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var categories = _db.Categories.ToList();
            return PartialView(categories);
        }

       public ActionResult ProductsSuggestions(string term)
        {
            var products = _db.Products.Where(p => p.Name.ToLower().Contains(term.ToLower())).Take(5).Select(p => new { label = p.Name });

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}