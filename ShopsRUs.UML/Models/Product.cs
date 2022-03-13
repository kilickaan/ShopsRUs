using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.UML.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductType { get; set; }
    }
}
