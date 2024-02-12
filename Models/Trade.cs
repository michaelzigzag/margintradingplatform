using System;

public enum TradeMode
{
    Hedging,
    Netting
}

public class Trade
{
    public string TradeId { get; set; }
    public string AccountId { get; set; }
    public string InstrumentId { get; set; }
    public DateTime TradeDate { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public bool IsBuy { get; set; }
    public decimal Commission { get; set; }
    public TradeMode Mode { get; set; }
}