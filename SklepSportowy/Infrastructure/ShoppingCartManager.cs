using SklepSportowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepSportowy.Infrastructure
{
    public class ShoppingCartManager
    {
        private SportStoreContext _db;

        private ISessionManager _session;

        public const string CartSessionKey = "CartData";

        public ShoppingCartManager(ISessionManager session, SportStoreContext db)
        {
            _db = db;
            _session = session;
        }

        public void AddToCart(int productID)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductID == productID);

            if (cartItem != null)
                cartItem.Quantity++;
            else
            {
                var productToAdd = _db.Products.Where(p => p.ProductID == productID).SingleOrDefault();
                if (productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };

                    cart.Add(newCartItem);
                }
            }
            _session.Set(CartSessionKey, cart);
        }
    
        public int RemoveFromCart(int productID)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(p => p.Product.ProductID == productID);

            if(cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                    cart.Remove(cartItem);

            }

            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetCartTotalCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(c => c.Quantity);

            return count;
        }
    
       
        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if(_session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = _session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }

            return cart;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;
            //newOrder.UserId = userId;

            this._db.Orders.Add(newOrder);
            if (newOrder.OrderItems == null)
                newOrder.OrderItems = new List<OrderItem>();

            decimal cartTotal = 0;

            foreach(var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductID = cartItem.Product.ProductID,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.ProductID
                };

                cartTotal += (cartItem.Quantity * cartItem.Product.Price);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrice = cartTotal;

            this._db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            _session.Set < List<CartItem>>(CartSessionKey, null);
        }
    }

}