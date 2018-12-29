using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretF.Models
{
    public class Blog:MyEntityBase
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime AddedDate { get; set; }

        public string Description { get; set; }

        public string ProductImage { get; set; }

        public string ProductName { get; set; }

        public int ReadCount { get; set; }
    }
}