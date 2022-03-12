using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class Invoice
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; } = string.Empty;
        public string AllowanceAmount { get; set; }
        public string PayableAmount { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<InvoiceLine> ListInvoiceLine { get; set; }
    }

    public class InvoiceLine
    {
        public int Line { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string PriceAmount { get; set; }
    }
}
