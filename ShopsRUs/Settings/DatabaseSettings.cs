using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string InvoiceCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
