using System;

public class TradeExecutionRouter : ITradeExecutionRouter
{
    private readonly ILiquidityProvider _liquidityProvider;

    public TradeExecutionRouter(ILiquidityProvider liquidityProvider)
    {
        _liquidityProvider = liquidityProvider;
    }

    public void ExecuteTrade(Trade trade, TradeExecutionMode executionMode)
    {
        switch (executionMode)
        {
            case TradeExecutionMode.Manual:
                // Use the liquidity provider for manual trade execution
                _liquidityProvider.ExecuteTrade(trade);
                break;
            case TradeExecutionMode.Automatic:
                // Automatic execution simply logs confirmation for now
                AutomaticExecuteTrade(trade);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(executionMode), $"Unsupported execution mode: {executionMode}");
        }
    }

    private void ManualExecuteTrade(Trade trade)
    {
        // This method is now handled by the liquidity provider
    }

    private void AutomaticExecuteTrade(Trade trade)
    {
        // Automatic trade execution with confirmation
        Console.WriteLine($"Trade {trade.TradeId} automatically confirmed.");
    }
}