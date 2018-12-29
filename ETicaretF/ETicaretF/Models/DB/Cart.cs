using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class Cart
    {
        public Product Product { get; set; }

        public int Count { get; set; }

        public decimal Tutar
        {
            get
            {
                return Product.Price * Count;
            }
        }
    }
}