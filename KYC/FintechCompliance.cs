using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class FintechCompliance
    {
        static public bool Check(Customer customer,String signature)
        {
            bool result = true;

            if (customer.Photo==false) { result = false; }
            if(customer.Name!=signature) { result = false; }
            return result;

        }
    }
}
