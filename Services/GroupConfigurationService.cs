using System.Collections.Generic;
using System.Linq;

public class GroupConfigurationService : IGroupConfigurationService
{
    private readonly List<GroupConfiguration> _configurations = new List<GroupConfiguration>();
    private readonly Dictionary<string, List<MarginConfiguration>> _marginConfigurations = new Dictionary<string, List<MarginConfiguration>>();

    public GroupConfigurationService()
    {
        // Initial setup or loading configurations from a persistent store could occur here.
    }

    public void ConfigureInstrumentGroupsForAccountGroup(string accountGroupId, List<string> instrumentGroupIds)
    {
        var configuration = _configurations.FirstOrDefault(c => c.AccountGroupId == accountGroupId);
        
        if (configuration == null)
        {
            configuration = new GroupConfiguration
            {
                AccountGroupId = accountGroupId,
                InstrumentGroupIds = instrumentGroupIds
            };
            _configurations.Add(configuration);
        }
        else
        {
            configuration.InstrumentGroupIds = instrumentGroupIds;
        }
    }

    public List<string> GetConfiguredInstrumentGroupIdsForAccountGroup(string accountGroupId)
    {
        var configuration = _configurations.FirstOrDefault(c => c.AccountGroupId == accountGroupId);
        return configuration?.InstrumentGroupIds ?? new List<string>();
    }
    public List<MarginConfiguration> GetMarginConfigurations(string accountGroupId)
    {
        return _marginConfigurations[accountGroupId];
    }

    public void SetMarginConfiguration(string accountGroupId, List<MarginConfiguration> marginConfigurations)
    {
        _marginConfigurations[accountGroupId] = marginConfigurations;
    }
    // Implementation for margin configurations remains as previously outlined
}