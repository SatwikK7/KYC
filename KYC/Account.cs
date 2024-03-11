using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    internal class Account
    {
        public string AccountNumber { get; private set; }
        public DateTime LastLogin { get; private set; }
        public string LastTransactionRecipient { get; private set; }
        public decimal LastTransactionAmount { get; private set; }

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;

            // Initialize last login info to current time
            LastLogin = DateTime.Now;

            // Initialize transaction details to default values
            LastTransactionRecipient = "No recent transaction";
            LastTransactionAmount = 0;
        }

        public void UpdateLastLogin()
        {
            // Update last login time to current time
            Console.WriteLine("You can make transaction now");
            LastLogin = DateTime.Now;
        }

        public void UpdateLastTransaction(string recipient, decimal amount)
        {
            // Update last transaction details

            LastTransactionRecipient = recipient;
            LastTransactionAmount = amount;
        }
    }
}
