using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string IconFilename { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
