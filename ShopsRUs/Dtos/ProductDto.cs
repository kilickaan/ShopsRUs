using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductType { get; set; }
    }
}
