using Microsoft.AspNetCore.Mvc;
using FishFocus.Services;
using FishFocus.Shared.Models;

namespace FishFocus.Controllers;

[ApiController]
[Route("api/[controller]")] // адрес api/fishery
public class FisheryController : ControllerBase
{
    private readonly FishingService _fishingService;

    public FisheryController(FishingService fishingService)
    {
        _fishingService = fishingService;
    }

    [HttpGet("catch")]
    public async Task<ActionResult<Fish>> GetCatch([FromQuery] int minutes)
    {
        var result = await _fishingService.CalculateReward(minutes);
        return Ok(result);
    }
}
