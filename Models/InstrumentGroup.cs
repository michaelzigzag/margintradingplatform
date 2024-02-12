using System.Collections.Generic;

public class InstrumentGroup
{
    public string InstrumentGroupId { get; set; }
    public string Name { get; set; }
    public List<string> InstrumentIds { get; set; } = new List<string>();
}