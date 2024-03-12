using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class Monitoring
    {
        static public bool CheckTransactionAmount(decimal transactionAmount)
        {
            // Check if transaction amount is more than 100,000
            if( transactionAmount <= 100000)
            {
                Console.WriteLine("Monitoring --> Passed");
                return true;
            }
                Console.WriteLine("Monitoring --> Failed, You have exceeded your transaction limit");
                return false;
        }

        static public void GetLastLoginDetails(Customer customer)
        {
            // Retrieve and display last login details of the customer's account
            Console.WriteLine($"Login Info for {customer.Name}:");
            Console.WriteLine($"Last Login Time: {customer.UserAccount.LastLogin}");
            Console.WriteLine($"Last Transaction Recipient: {customer.UserAccount.LastTransactionRecipient}");
            Console.WriteLine($"Last Transaction Amount: {customer.UserAccount.LastTransactionAmount}");
        }
    }
}
