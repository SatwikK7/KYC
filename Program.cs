using System;
using Oracle.ManagedDataAccess.Client;

string description = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
string connectionString = $"Data Source={description};User Id=system;Password=password";

try
{
    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Connected to Oracle database!");

        using (var db = new TradeDataContext(connection))
        {
            // Insert data
            TradeClass newTrade = new TradeClass { BOManager = "John Doe" };
            db.Trades.InsertOnSubmit(newTrade);
            db.SubmitChanges();
            Console.WriteLine("Data inserted successfully!");

            // Display data
            var trades = db.Trades;
            Console.WriteLine("Trades Table Contents:");
            foreach (var trade in trades)
            {
                Console.WriteLine($"BO Manager: {trade.BOManager}");
            }
        }
    }
}
catch (OracleException ex)
{
    Console.WriteLine("Oracle Error:");
    Console.WriteLine("  Message: " + ex.Message);
    Console.WriteLine("  Error Code: " + ex.Number);
    Console.WriteLine("  Source: " + ex.Source);
    Console.WriteLine("  StackTrace: " + ex.StackTrace);
}
catch (Exception ex)
{
    Console.WriteLine("Error:");
    Console.WriteLine("  Message: " + ex.Message);
    Console.WriteLine("  StackTrace: " + ex.StackTrace);
}

