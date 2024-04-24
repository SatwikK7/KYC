using System.Data;
using System.Data.Linq;

public class TradeDataContext : DataContext
{
    public Table<TradeClass> Trades { get { return GetTable<TradeClass>(); } }

    public TradeDataContext(string connection) : base(connection) { }

    public TradeDataContext(IDbConnection connection) : base(connection)
    {
    }
}
