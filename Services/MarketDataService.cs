using System;
using System.Collections.Generic;
using System.Linq;

public class MarketDataService : IMarketDataService
{
    // Simulated data store for current prices (in a real application, this would likely query a live data source)
    private Dictionary<string, decimal> _currentPrices = new Dictionary<string, decimal>
    {
        { "Instrument1", 100.5m },
        { "Instrument2", 200.75m }
    };

    // Simulated data store for historical prices
    private Dictionary<string, List<PriceBar>> _historicalData = new Dictionary<string, List<PriceBar>>
    {
        { "Instrument1", new List<PriceBar> 
            { 
                new PriceBar { Time = DateTime.Now.AddDays(-1), Open = 100m, High = 110m, Low = 95m, Close = 105m, Volume = 10000 },
                new PriceBar { Time = DateTime.Now.AddDays(-2), Open = 105m, High = 115m, Low = 100m, Close = 110m, Volume = 15000 }
            }
        },
        { "Instrument2", new List<PriceBar>
            {
                new PriceBar { Time = DateTime.Now.AddDays(-1), Open = 200m, High = 210m, Low = 195m, Close = 205m, Volume = 15000 },
                new PriceBar { Time = DateTime.Now.AddDays(-2), Open = 205m, High = 215m, Low = 200m, Close = 210m, Volume = 20000 }
            }
        }
    };

    public decimal? GetCurrentPrice(string instrumentId)
    {
        if (_currentPrices.TryGetValue(instrumentId, out decimal price))
        {
            return price;
        }
        return null;
    }

    public List<PriceBar> GetHistoricalBars(string instrumentId, int days)
    {
        if (_historicalData.TryGetValue(instrumentId, out List<PriceBar> bars))
        {
            return bars.Take(days).ToList();
        }
        return new List<PriceBar>();
    }
}