using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class Enums
    {
        public enum UserTypes
        {
            Employee = 1,
            Affiliate = 2,
            Customer = 3
        }

        public enum ApplyFor
        {
            Default = 1,
            Groceries = 2
        }

        public enum DiscountPercentage
        {
            EmployeeDiscount = 30,
            AffiliateDiscount = 10,
            CustomerOver2YearDiscount = 5,
            Each100DollarDiscount = 5
        }
    }
}
