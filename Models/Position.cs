public enum PositionMode
{
    Hedging,
    Netting
}

public class Position
{
    public string PositionId { get; set; }
    public string AccountId { get; set; }
    public string InstrumentId { get; set; }
    public decimal Quantity { get; set; }
    public decimal AverageOpenPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal UnrealizedPL { get; set; }
    public PositionMode Mode { get; set; }
}