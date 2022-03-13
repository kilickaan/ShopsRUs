using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.UML.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public double AllowanceAmount { get; set; }
        public double AllowancePercentage { get; set; }
        public double PayableAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        ICollection<Customer> CustomerId { get; set; }
        ICollection<InvoiceLine> lineid { get; set; }
    }
}
