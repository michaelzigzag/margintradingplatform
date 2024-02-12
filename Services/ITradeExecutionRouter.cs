public interface ITradeExecutionRouter
{
    void ExecuteTrade(Trade trade, TradeExecutionMode executionMode);
}