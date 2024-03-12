using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class CyberSecurity
    {

        static public bool CheckSQLInjection(string input)
        {
            string[] sqlKeywords = { "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "TABLE", "FROM", "WHERE" };
            foreach (var keyword in sqlKeywords)
            {
                if (input.ToUpper().Contains(keyword))
                {
                    Console.WriteLine("Cybersecurity --> Failed at SQL check");
                    return false; 
                }
            }
            Console.WriteLine("Cybersecurity --> Passed");
            return true; 
        }

        static public bool DDoS(Customer customer, Dictionary<string,int> myDictionary)
        {
            string acc = customer.UserAccount.AccountNumber;
            if (myDictionary.ContainsKey(acc))
            {
                myDictionary[acc]++;
            }
            else
            {
                myDictionary[acc] = 1; 
            }
            if (myDictionary[acc]>2) {
                Console.WriteLine("Cybersecurity ---> Failed,DDoS detected");
                return false;
            }
            return true;
        }

    }
}
