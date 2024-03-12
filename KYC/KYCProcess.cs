using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    internal class KYCProcess : IKYCRule
    {
        Dictionary<string, int> transactions = new Dictionary<string, int>();
        public bool Verify(Customer customer,String sign)
        { 
         
            bool result = FintechCompliance.Check(customer,sign);
            result = result && CyberSecurity.DDoS(customer, transactions);
            result = result && CyberSecurity.CheckSQLInjection(customer.UserAccount.LastTransactionRecipient);

           // result = result && CyberSecurity.CheckSQLInjection(sign);

            result = result && AML.ExternalCheck(customer) && AML.InternalCheck(customer);
            string customerRisk = Risk.GetCustomerCategory(customer);
            if(customerRisk == "High Risk") 
            {
                Console.WriteLine("Risk --> Failed, You have been marked under high risk");
                result = false; 
            }
            else
            {
                Console.WriteLine("Rsk --> Passed");
            }
            result = result && Monitoring.CheckTransactionAmount(customer.UserAccount.LastTransactionAmount);
            return result;
        }

    }
}
