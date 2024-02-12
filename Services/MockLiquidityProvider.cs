using System;

public class MockLiquidityProvider : ILiquidityProvider
{
    public bool ExecuteTrade(Trade trade)
    {
        // Simulate trade execution logic with an external liquidity provider
        Console.WriteLine($"Trade {trade.TradeId} executed with external liquidity provider.");
        return true; // Assume execution is successful
    }
}