using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class InvoiceLineDto
    {
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string PriceAmount { get; set; }
    }
}
