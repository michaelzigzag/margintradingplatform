using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TradeController : ControllerBase
{
    private readonly ITradeExecutionRouter _tradeExecutionRouter;
    private readonly IMarketDataService _marketDataService;

    public TradeController(ITradeExecutionRouter tradeExecutionRouter, IMarketDataService marketDataService)
    {
        _tradeExecutionRouter = tradeExecutionRouter;
        _marketDataService = marketDataService;
    }

    [HttpPost]
    public IActionResult PlaceTrade([FromBody] Trade trade, [FromQuery] TradeExecutionMode executionMode)
    {
        _tradeExecutionRouter.ExecuteTrade(trade, executionMode);
        return Ok();
    }

    // Additional actions can be added here
}