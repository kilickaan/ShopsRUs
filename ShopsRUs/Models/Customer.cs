using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserTypeId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
