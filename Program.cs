using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;

namespace db_conn
{
    class Program
    {

        static void Main(string[] args)
        {
            string description = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
            string connectionString = $"Data Source={description};User Id=system;Password=password";

            List<Trade> trades = new List<Trade>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to Oracle database!");

                    while (true)
                    {
                        Console.WriteLine("\n\nPress\n 1 to display data of the table\n 2 to insert the data \n 3 to update \n 4 to delete \n 5 to view trades happened today \n 0 to exit");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 0)
                            break;

                        switch (choice)
                        {
                            case 1:
                                trades = RetrieveTrades(connection);
                                DisplayTableContents(trades);
                                break;

                            case 2:
                                InsertData(connection);
                                break;

                            case 3:
                                Console.WriteLine("Enter the contract id whose Counterparty needs to be identified and the new Counterparty:");
                                int update = Convert.ToInt32(Console.ReadLine());
                                string ctrParty = Console.ReadLine();
                                UpdateCounterPartyByContractID(connection, update, ctrParty);
                                break;

                            case 4:
                                Console.WriteLine("Enter the contract id of the record which you want to delete:");
                                int delete = Convert.ToInt32(Console.ReadLine());
                                DeleteRowByContractID(connection, delete);
                                break;

                            case 5:
                                trades = RetrieveTradesToday(connection);
                                DisplayTableContents(trades);
                                break;
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
            }
        }

        static List<Trade> RetrieveTrades(OracleConnection connection)
        {
            List<Trade> trades = new List<Trade>();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT BO_MANAGER, BO_FOLLOWER, PORTFOLIO, COMPANY, COUNTERPARTY, CONTRACT_ID, Trade_Date FROM Trade";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Trade trade = new Trade
                        {
                            BOManager = reader.GetString(0),
                            BOFollower = reader.GetString(1),
                            Portfolio = reader.GetString(2),
                            Company = reader.GetInt32(3),
                            Counterparty = reader.GetString(4),
                            ContractID = reader.GetInt32(5),
                            TradeDate = reader.GetDateTime(6) 
                        };
                        trades.Add(trade);
                    }
                }
            }

            return trades;
        }

        static List<Trade> RetrieveTradesToday(OracleConnection connection)
        {
            List<Trade> trades = new List<Trade>();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT BO_MANAGER, BO_FOLLOWER, PORTFOLIO, COMPANY, COUNTERPARTY, CONTRACT_ID, Trade_Date FROM Trade WHERE Trade_Date = TRUNC(SYSDATE)";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Trade trade = new Trade
                        {
                            BOManager = reader.GetString(0),
                            BOFollower = reader.GetString(1),
                            Portfolio = reader.GetString(2),
                            Company = reader.GetInt32(3),
                            Counterparty = reader.GetString(4),
                            ContractID = reader.GetInt32(5),
                            TradeDate = reader.GetDateTime(6) 
                        };
                        trades.Add(trade);
                    }
                }
            }

            return trades;
        }

        static void DisplayTableContents(IEnumerable<Trade> trades)
        {
            Console.WriteLine("Trades Table Contents:");
            foreach (var trade in trades)
            {
                Console.WriteLine($"BO Manager: {trade.BOManager}, BO Follower: {trade.BOFollower}, Portfolio: {trade.Portfolio}, Company: {trade.Company}, Counterparty: {trade.Counterparty}, Contract ID: {trade.ContractID}, Trade Date: {trade.TradeDate.ToString("yyyy-MM-dd")}");
            }
        }

        static void InsertData(OracleConnection connection)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Trade (BO_MANAGER, BO_FOLLOWER, PORTFOLIO, COMPANY, COUNTERPARTY, CONTRACT_ID, Trade_Date) VALUES (:boManager, :boFollower, :portfolio, :company, :counterparty, :contractID, TRUNC(SYSDATE))";
                cmd.Parameters.Add("boManager", OracleDbType.Varchar2).Value = "Alice";
                cmd.Parameters.Add("boFollower", OracleDbType.Varchar2).Value = "Bob";
                cmd.Parameters.Add("portfolio", OracleDbType.Varchar2).Value = "Portfolio2";
                cmd.Parameters.Add("company", OracleDbType.Int32).Value = 123;
                cmd.Parameters.Add("counterparty", OracleDbType.Varchar2).Value = "Counterparty2";
                cmd.Parameters.Add("contractID", OracleDbType.Int32).Value = 166;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully!");
            }
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

       
        class Trade
        {
            public string BOManager { get; set; }
            public string BOFollower { get; set; }
            public string Portfolio { get; set; }
            public int Company { get; set; }
            public string Counterparty { get; set; }
            public int ContractID { get; set; }
            public DateTime TradeDate { get; set; } 
        }
    }
}
