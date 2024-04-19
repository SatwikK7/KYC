using System;
using Oracle.ManagedDataAccess.Client;

class Program
{
    static void Main()
    {
        string connectionString = "User Id=satwik;Password=system;Data Source=//localhost:1521/xe;Connection Timeout=30";

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected to Oracle database!");

                // Perform database operations here

                connection.Close();
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Oracle Error: " + ex.Message);
                Console.WriteLine("Error Code: " + ex.Number);
                Console.WriteLine("Source: " + ex.Source);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }
    }
}
