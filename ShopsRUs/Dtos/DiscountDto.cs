using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class DiscountDto
    {
        public string Id { get; set; }
        public int DiscountType { get; set; }
        public int DiscountRate { get; set; }
    }
}
