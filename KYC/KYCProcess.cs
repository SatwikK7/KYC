using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    internal class KYCProcess : IKYCRule
    {
        public bool Verify(Customer customer,String sign)
        { 
            bool result = FintechCompliance.Check(customer,sign);
            result = result && CyberSecurity.CheckSQLInjection(sign);
            result = result && AML.ExternalCheck(customer) && AML.InternalCheck(customer);
            string customerRisk = Risk.GetCustomerCategory(customer);
            if(customerRisk == "High Risk") { result = false; }
            result = result && Monitoring.CheckTransactionAmount(customer.UserAccount.LastTransactionAmount);
            return result;
        }

    }
}
