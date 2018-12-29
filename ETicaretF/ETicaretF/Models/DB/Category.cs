using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class Category : MyEntityBase
    {
        public string Title { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}