// See https://aka.ms/new-console-template for more information
using KYC;

Console.WriteLine("WELCOME TO THE KYC PROCESS");

Customer user1 = new Customer("John", true, 1234, "AC123456", "john@example.com", "123 Main St", 100, 800);
Customer user2 = new Customer("Alice", true, 5678, "AC789012", "alice@example.com", "456 Elm St", 600, 600);
Customer user3 = new Customer("Bob", false, 91011, "AC345678", "bob@example.com", "789 Oak St", 700, 400);
Customer user4 = new Customer("Eve", true, 121314, "AC901234", "eve@example.com", "101 Pine St", 400, 850);

KYCProcess kycProcess = new KYCProcess();
bool kycResult1 = kycProcess.Verify(user1, "John");
bool kycResult2 = kycProcess.Verify(user2, "Alice");
bool kycResult3 = kycProcess.Verify(user3, "Bob");
bool kycResult4 = kycProcess.Verify(user4, "Eve");

// Print out the results
Console.WriteLine("KYC Result for user 1: " + (kycResult1 ? "Passed" : "Failed"));
Console.WriteLine("KYC Result for user 2: " + (kycResult2 ? "Passed" : "Failed"));
Console.WriteLine("KYC Result for user 3: " + (kycResult3 ? "Passed" : "Failed"));
Console.WriteLine("KYC Result for user 4: " + (kycResult4 ? "Passed" : "Failed"));