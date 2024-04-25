using System;
using Oracle.ManagedDataAccess.Client;
using System.Data.Linq;


string description = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
string connectionString = $"Data Source={description};User Id=system;Password=password";

OracleConnection connection = null;

try
{
    connection = new OracleConnection(connectionString);
    connection.Open();
    Console.WriteLine("Connected to Oracle database!");


    //InsertDataWithoutLINQ(connection);

    //DisplayTableContents(connection);

    //DeleteRowByContractID(connection, 456);

    // Update CounterParty for a given ContractID

    //UpdateCounterPartyByContractID(connection, 456, "New Counterparty");

    //using (var db = new TradeDataContext(connection))
    //{
    //    //InsertDataWithLINQ(db);
    //    var trades = db.Trades.ToList();
    //    Console.WriteLine("Trades Table Contents:");
    //    foreach (var trade in trades)
    //    {
    //        Console.WriteLine($"BO Manager: {trade.BOManager}, BO Follower: {trade.BOFollower}, Portfolio: {trade.Portfolio}, Company: {trade.Company}, Counterparty: {trade.Counterparty}, Contract ID: {trade.ContractID}");
    //    }
    //}

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
finally
{
    connection?.Close();
}


static void InsertDataWithoutLINQ(OracleConnection connection)
{
    using (var cmd = connection.CreateCommand())
    {
        cmd.CommandText = "INSERT INTO Trade (BO_MANAGER, BO_FOLLOWER, PORTFOLIO, COMPANY, COUNTERPARTY, CONTRACT_ID) VALUES (:boManager, :boFollower, :portfolio, :company, :counterparty, :contractID)";
        cmd.Parameters.Add("boManager", OracleDbType.Varchar2).Value = "John Doe";
        cmd.Parameters.Add("boFollower", OracleDbType.Varchar2).Value = "Jane Smith";
        cmd.Parameters.Add("portfolio", OracleDbType.Varchar2).Value = "Portfolio1";
        cmd.Parameters.Add("company", OracleDbType.Int32).Value = 123;
        cmd.Parameters.Add("counterparty", OracleDbType.Varchar2).Value = "Counterparty1";
        cmd.Parameters.Add("contractID", OracleDbType.Int32).Value = 456;

        cmd.ExecuteNonQuery();
        Console.WriteLine("Data inserted without LINQ successfully!");
    }
}

static void DisplayTableContents(OracleConnection connection)
{
    using (var cmd = connection.CreateCommand())
    {
        cmd.CommandText = "SELECT BO_MANAGER, BO_FOLLOWER, PORTFOLIO, COMPANY, COUNTERPARTY, CONTRACT_ID FROM Trade";
        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine("Trades Table Contents:");
            while (reader.Read())
            {
                Console.WriteLine($"BO Manager: {reader.GetString(0)}, BO Follower: {reader.GetString(1)}, Portfolio: {reader.GetString(2)}, Company: {reader.GetInt32(3)}, Counterparty: {reader.GetString(4)}, Contract ID: {reader.GetInt32(5)}");
            }
        }
    }
}

static void InsertDataWithLINQ(TradeDataContext db)
{
    TradeClass newTrade = new TradeClass { BOManager = "Alice", BOFollower = "Bob", Portfolio = "Portfolio2", Company = 12, Counterparty = "Counterparty2", ContractID = 10 };

    // Insert data using LINQ to SQL
    db.Trades.InsertOnSubmit(newTrade);
    db.SubmitChanges();

    Console.WriteLine("Data inserted using LINQ to SQL successfully!");
}

static void DeleteRowByContractID(OracleConnection connection, int contractID)
{
    string deleteCommandText = "DELETE FROM Trade WHERE CONTRACT_ID = :contractID";
    using (var cmd = new OracleCommand(deleteCommandText, connection))
    {
        cmd.Parameters.Add("contractID", OracleDbType.Int32).Value = contractID;
        int rowsAffected = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rowsAffected} row(s) deleted for ContractID {contractID}.");
    }
}

static void UpdateCounterPartyByContractID(OracleConnection connection, int contractID, string newCounterparty)
{
    string updateCommandText = "UPDATE Trade SET COUNTERPARTY = :newCounterparty WHERE CONTRACT_ID = :contractID";
    using (var cmd = new OracleCommand(updateCommandText, connection))
    {
        cmd.Parameters.Add("newCounterparty", OracleDbType.Varchar2).Value = newCounterparty;
        cmd.Parameters.Add("contractID", OracleDbType.Int32).Value = contractID;
        int rowsAffected = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rowsAffected} row(s) updated for ContractID {contractID}.");
    }
}

