using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.UML.Models
{
    public class InvoiceLine
    {
        public int id { get; set; }
        public int Quantity { get; set; }
        ICollection<Product> ProductId { get; set; }
    }
}
