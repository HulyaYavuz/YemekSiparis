using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class OrderDetail : MyEntityBase
    {
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<double> Sale { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}