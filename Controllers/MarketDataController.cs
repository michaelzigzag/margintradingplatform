using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MarketDataController : ControllerBase
{
    private readonly IMarketDataService _marketDataService;

    public MarketDataController(IMarketDataService marketDataService)
    {
        _marketDataService = marketDataService;
    }

    // Get the current price for a given instrument
    [HttpGet("currentPrice/{instrumentId}")]
    public IActionResult GetCurrentPrice(string instrumentId)
    {
        var price = _marketDataService.GetCurrentPrice(instrumentId);
        if (price == null)
        {
            return NotFound($"Current price information for instrument ID {instrumentId} not found.");
        }

        return Ok(price);
    }

    // Additional actions...
}