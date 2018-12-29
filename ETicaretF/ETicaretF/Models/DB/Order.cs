using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class Order : MyEntityBase
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public Nullable<int> CustomerID { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}