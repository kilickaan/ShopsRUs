using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.UML.Models
{
    public class  Enums
    {
        public enum UserTypes
        {
            Employee = 1,
            Affiliate = 2,
            Customer = 3
        }

        public enum DiscountTypes
        {
            EmployeeDiscount = 1,
            AffiliateDiscount = 2,
            Customer = 3
        }

        public enum ProductType
        {
            Groceries = 1,
            Others = 0
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
