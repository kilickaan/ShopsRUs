using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class InvoiceLineDto
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
