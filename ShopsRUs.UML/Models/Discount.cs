using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.UML.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public int DiscountType { get; set; }
        public int DiscountRate { get; set; }
    }
}
