using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class Customer:MyEntityBase
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string BillAdress { get; set; }

        public string DeliveryAdress { get; set; }

        public string PayType { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}