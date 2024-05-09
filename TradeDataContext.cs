// ﻿using System.Data;
// using System.Data.Linq;

// public class TradeDataContext : DataContext
// {
//     public Table<TradeClass> Trades { get { return GetTable<TradeClass>(); } }

//     public TradeDataContext(string connection) : base(connection) { }

//     public TradeDataContext(IDbConnection connection) : base(connection)
//     {
//     }
// }

        static List<Trade> ReadFromCsvAndUpdateDB(string filePath, OracleConnection connection)
        {
            List<Trade> trades = new List<Trade>();

            // Read data from CSV file
            var lines = File.ReadAllLines(filePath);

            // Skip header if exists
            var dataLines = lines.Skip(1);

            // Process each line
            foreach (var line in dataLines)
            {
                // Split the line by comma
                var values = line.Split(',');

                // Create Trade object
                Trade trade = new Trade
                {
                    BOManager = values[0],
                    BOFollower = values[1],
                    Portfolio = values[2],
                    Company = Convert.ToInt32(values[3]),
                    Counterparty = values[4],
                    ContractID = Convert.ToInt32(values[5])
                };

                // Add Trade object to list
                trades.Add(trade);

                // Insert/update database
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Trade (BO_MANAGER, BO_FOLLOWER, PORTFOLIO, COMPANY, COUNTERPARTY, CONTRACT_ID, Trade_Date) " +
                                      "VALUES (:boManager, :boFollower, :portfolio, :company, :counterparty, :contractID, TRUNC(SYSDATE))";
                    cmd.Parameters.Add("boManager", OracleDbType.Varchar2).Value = trade.BOManager;
                    cmd.Parameters.Add("boFollower", OracleDbType.Varchar2).Value = trade.BOFollower;
                    cmd.Parameters.Add("portfolio", OracleDbType.Varchar2).Value = trade.Portfolio;
                    cmd.Parameters.Add("company", OracleDbType.Int32).Value = trade.Company;
                    cmd.Parameters.Add("counterparty", OracleDbType.Varchar2).Value = trade.Counterparty;
                    cmd.Parameters.Add("contractID", OracleDbType.Int32).Value = trade.ContractID;
                    cmd.ExecuteNonQuery();
                }
            }

            return trades;
        }
