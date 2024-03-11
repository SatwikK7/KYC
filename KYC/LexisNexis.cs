using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class LexisNexis
    {
       static public bool GetTrust(Customer customer)
        {
            bool trust = true;

            string[] prohibited = { "AA", "BB", "CC", "DD", "EE" };
            string recipient = customer.UserAccount.LastTransactionRecipient.ToUpper();
            foreach (var keyword in prohibited)
            {
                if (recipient == keyword)
                {
                    trust = false;
                    break; 
                }
            }

            return trust;
   
        }
    }
}
