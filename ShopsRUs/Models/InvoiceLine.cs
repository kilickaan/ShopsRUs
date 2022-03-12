using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class InvoiceLine
    {
        public string ItemName { get; set; } 
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string PriceAmount { get; set; }
    }
}
