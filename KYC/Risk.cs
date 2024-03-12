using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class Risk
    {
        static public string GetCustomerCategory(Customer customer)
        {
            if (customer.PendingLoan < 500 && customer.CreditScore > 700)
            {
                return "Low risk";
            }
            else if (customer.PendingLoan > 500 || customer.CreditScore < 700)
            {
                return "High risk";
            }
            else
            {
                return "Medium risk";
            }
        }
    }
}
