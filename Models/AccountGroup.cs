using System.Collections.Generic;

public class AccountGroup
{
    public string AccountGroupId { get; set; }
    public string Name { get; set; }
    public List<string> AccountIds { get; set; } = new List<string>();
}