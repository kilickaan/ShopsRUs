using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{

    public class Invoice
    {
       
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string InvoiceId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        public double AllowanceAmount { get; set; }
        public double AllowancePercentage { get; set; }
        public double PayableAmount { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<InvoiceLine> InvoiceLine { get; set; }
    }
}
