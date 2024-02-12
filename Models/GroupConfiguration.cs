using System.Collections.Generic;

public class MarginConfiguration
{
    public string InstrumentGroupId { get; set; }
    public decimal MarginRate { get; set; } // Margin requirement rate (e.g., 0.1 for 10% margin)
}

public class GroupConfiguration
{
    public string AccountGroupId { get; set; }
    public List<string> InstrumentGroupIds { get; set; } = new List<string>();
    public List<MarginConfiguration> MarginConfigurations { get; set; } = new List<MarginConfiguration>();
}