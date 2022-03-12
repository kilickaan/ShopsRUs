using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Dtos
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserTypeId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
