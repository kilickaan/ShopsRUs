using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class InvoiceDto
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;


    }
}
