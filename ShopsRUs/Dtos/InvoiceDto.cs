using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class InvoiceDto
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; } 
        public string CustomerId { get; set; }
        public double AllowanceAmount { get; set; }
        public int AllowancePercentage { get; set; }
        public double PayableAmount { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<InvoiceLine> InvoiceLine { get; set; }

    }
}
