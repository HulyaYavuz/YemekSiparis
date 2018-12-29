using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class CartModels
    {
        public CartModels()
        {
            Product = new Dictionary<int, int>();

        }

        public Dictionary<int, int> Product { get; }
    }
}