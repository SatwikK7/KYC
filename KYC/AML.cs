using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class AML
    {
        static public bool ExternalCheck(Customer customer)
        {
            bool result = true;
            if( LexisNexis.GetTrust(customer) == false) { result = false; }
            return result;
        }

       static public bool InternalCheck(Customer customer) { 
            bool result = true;

            return result;
       }
    }
}
