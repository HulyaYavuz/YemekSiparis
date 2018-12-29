using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class ProductItem : MyEntityBase
    {
        public string ItemName { get; set; }

        public int Count { get; set; }

        public virtual Product Product { get; set; }
    }
}