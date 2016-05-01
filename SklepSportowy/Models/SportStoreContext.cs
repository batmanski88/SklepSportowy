
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy.Models
{
    public class SportStoreContext : DbContext
    {
        public SportStoreContext() 
            :base("SportStoreDB")
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
