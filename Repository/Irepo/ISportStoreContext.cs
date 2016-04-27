using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Irepo
{
    public interface ISportStoreContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
    }
}
