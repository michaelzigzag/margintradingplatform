using System.Collections.Generic;

public interface IGroupConfigurationService
{
    void ConfigureInstrumentGroupsForAccountGroup(string accountGroupId, List<string> instrumentGroupIds);
    List<string> GetConfiguredInstrumentGroupIdsForAccountGroup(string accountGroupId);
    void SetMarginConfiguration(string accountGroupId, List<MarginConfiguration> marginConfigurations);
    List<MarginConfiguration> GetMarginConfigurations(string accountGroupId);
}