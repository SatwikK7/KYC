using System;

namespace KYC
{
    internal class Customer
    {
        public string Name { get;  set; }
        public bool Photo { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public string Address { get;  set; }
        public int PendingLoan { get;  set; }
        public int CreditScore { get;  set; }
        public Account UserAccount { get; set; }

        public Customer(string name, bool photo, int number , string email, string address, int pendingLoan, int creditScore,string accountNumber)
        {
            Name = name;
            Photo = photo;
            Number = number;
            Email = email;
            Address = address;
            PendingLoan = pendingLoan;
            CreditScore = creditScore;
            UserAccount = new Account(accountNumber);
        }
        public void Login()
        {
            UserAccount.UpdateLastLogin();
        }

        public void Transaction(string recipient, decimal amount)
        {
            UserAccount.UpdateLastTransaction(recipient, amount);
        }
    }
}
