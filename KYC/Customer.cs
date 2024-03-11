using System;

namespace KYC
{
    internal class Customer
    {
        public string Name { get;  set; }
        public bool Photo { get; set; }
        public int Number { get; set; }
        public string AccountNumber { get;  set; }
        public string Email { get; set; }
        public string Address { get;  set; }
        public int PendingLoan { get;  set; }
        public int CreditScore { get;  set; }

        public Customer(string name, bool photo, int number, string accountNumber, string email, string address, int pendingLoan, int creditScore)
        {
            Name = name;
            Photo = photo;
            Number = number;
            AccountNumber = accountNumber;
            Email = email;
            Address = address;
            PendingLoan = pendingLoan;
            CreditScore = creditScore;
        }
    }
}
