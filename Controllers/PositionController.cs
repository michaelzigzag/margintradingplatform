using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class PositionController : ControllerBase
{
    private static List<Position> positions = new List<Position>();

    [HttpGet]
    public ActionResult<IEnumerable<Position>> GetAllPositions()
    {
        return Ok(positions);
    }

    [HttpGet("{id}")]
    public ActionResult<Position> GetPositionById(string id)
    {
        var position = positions.Find(p => p.PositionId == id);
        if (position == null) return NotFound();
        return Ok(position);
    }

    // Assuming a method to close a position might be needed
    [HttpDelete("{id}")]
    public IActionResult ClosePosition(string id)
    {
        var position = positions.Find(p => p.PositionId == id);
        if (position == null) return NotFound();

        positions.Remove(position);
        return NoContent();
    }
}