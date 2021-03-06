﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CovertFileName { get; set; }

        public virtual Category Category { get; set; }

    }
}
