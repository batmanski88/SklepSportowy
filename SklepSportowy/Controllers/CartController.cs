
using SklepSportowy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SklepSportowy.Models;
using SklepSportowy.ViewModels;

namespace SklepSportowy.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;

        private ISessionManager sessionManager { get; set; }

        private SportStoreContext _db = new SportStoreContext();

        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this._db);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };
            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productID)
        {
            int itemCount = shoppingCartManager.RemoveFromCart(productID);
            int cartItemsCount = shoppingCartManager.GetCartTotalCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel()
            {
                RemoveItemId = productID,
                RemoveItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemCount = cartItemsCount

            };

            return Json(result);
        }
    }
}