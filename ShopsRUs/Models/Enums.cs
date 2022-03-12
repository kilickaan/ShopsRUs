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

        public enum DiscountTypes
        {
            GroceryDiscount = 1,
            EmployeeDiscount = 2,
            AffiliateDiscount = 3,
            CustomerOver2YearDiscount = 4,
            DefaultCustomerDiscount = 5
        }

        public enum ProductType
        {
            Groceries = 1,
            Others = 2
        }

        public enum DiscountPercentage
        {
            EmployeeDiscount = 30,
            AffiliateDiscount = 10,
            CustomerOver2YearDiscount = 5,
            GroceryCustomerDiscount = 0
        }
    }
}
