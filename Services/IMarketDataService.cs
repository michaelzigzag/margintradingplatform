using System.Collections.Generic;

public interface IMarketDataService
{
    decimal? GetCurrentPrice(string instrumentId);
    List<PriceBar> GetHistoricalBars(string instrumentId, int days);
}