using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class Product:MyEntityBase
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string ProductImage { get; set; }

        public int Count { get; set; }

        public virtual List<ProductItem> ProductItems { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        public virtual Category Category { get; set; }
    }
}