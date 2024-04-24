using System.Data.Linq.Mapping;

[Table(Name = "Trade")]
public class TradeClass
{
    [Column(Name = "BO_MANAGER")]
    public string BOManager { get; set; }

    [Column(Name = "BO_FOLLOWER")]
    public string BOFollower { get; set; }

    [Column(Name = "PORTFOLIO")]
    public string Portfolio { get; set; }

    [Column(Name = "COMPANY")]
    public int Company { get; set; }

    [Column(Name = "COUNTERPARTY")]
    public string Counterparty { get; set; }

    [Column(Name = "CONTRACT_ID",IsPrimaryKey =true)]
    public int ContractID { get; set; }
}