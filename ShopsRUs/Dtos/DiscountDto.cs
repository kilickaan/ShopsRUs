using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class DiscountDto
    {
        public string Id { get; set; }
        public string DiscountName { get; set; }
        public string DiscountType { get; set; }
        public string DiscountRate { get; set; }
    }
}
