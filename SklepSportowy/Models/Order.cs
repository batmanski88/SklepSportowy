using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string CodeAndCity { get; set; }

        public string Phonenumber { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public DateTime DateCreated { get; set; }

        public OrderState OrderState { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }

    public enum OrderState
    {
        New,
        Shipped
    }
}
