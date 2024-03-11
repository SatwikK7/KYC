using KYC;
using System;

Console.WriteLine("WELCOME TO THE KYC PROCESS");

// Declare and initialize customers
Customer user1 = new Customer("John", true, 1234, "john@example.com", "123 Main St", 100, 800, "AC123456");
Customer user2 = new Customer("Alice", true, 5678, "alice@example.com", "456 Elm St", 600, 600, "AC789012");
Customer user3 = new Customer("Bob", false, 91011, "bob@example.com", "789 Oak St", 700, 400, "AC345678");
Customer user4 = new Customer("Eve", true, 121314, "eve@example.com", "101 Pine St", 400, 850, "AC901234");

// Perform KYC checks for each customer
Customer[] customers = new Customer[] { user1, user2, user3, user4 };



foreach (var customer in customers)
{
    customer.Login();

    Console.WriteLine($"Enter recipient's name for {customer.Name}:");
    string recipient = Console.ReadLine();

    Console.WriteLine($"Enter transaction amount for {customer.Name}:");
    decimal amount = decimal.Parse(Console.ReadLine());

    customer.Transaction(recipient, amount);
}
KYCProcess kycProcess = new KYCProcess();


bool kycResult1 = kycProcess.Verify(user1,"John");
bool kycResult2 = kycProcess.Verify(user2, "Alice");
bool kycResult3 = kycProcess.Verify(user3, "BOB");
bool kycResult4 = kycProcess.Verify(user4, "Eve");

// Print KYC results
PrintKYCResult(user1, kycResult1);
PrintKYCResult(user2, kycResult2);
PrintKYCResult(user3, kycResult3);
PrintKYCResult(user4, kycResult4);

void PrintKYCResult(Customer customer, bool result)
{
    Console.WriteLine($"KYC Result for {customer.Name}: {(result ? "Passed" : "Failed")}");
}
