using System.Data.Linq.Mapping;

[Table(Name = "Trade")]
public class TradeClass
{

    [Column(Name = "BO_MANAGER", IsPrimaryKey = true)]
    public string BOManager { get; set; }

}
