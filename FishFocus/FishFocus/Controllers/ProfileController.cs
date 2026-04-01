using FishFocus.Data;
using FishFocus.Shared.DTOs.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FishFocus.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProfileController(AppDbContext db)
    {
        _db = db;
    }

    // GET /api/profile
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();

        var user = await _db.Users.FindAsync(userId);
        if (user is null) return NotFound();

        return Ok(new UserProfileDto
        {
            Username = user.Username,
            Email = user.Email,
            TotalPoints = user.TotalPoints,
            CreatedAt = user.CreatedAt,

            IsNightMode = user.IsNightMode,
            PlayFog = user.PlayFog,

            IsRadioEnabled = user.IsRadioEnabled,
            RadioVolume = user.RadioVolume,

            IsRainEnabled = user.IsRainEnabled,
            RainVolume = user.RainVolume,

            IsBirdsEnabled = user.IsBirdsEnabled,
            BirdsVolume = user.BirdsVolume,

            IsWavesEnabled = user.IsWavesEnabled,
            WavesVolume = user.WavesVolume,

            IsThunderEnabled = user.IsThunderEnabled,
            ThunderVolume = user.ThunderVolume,
        });
    }

    // PUT /api/profile/settings
    [HttpPut("settings")]
    public async Task<IActionResult> UpdateSettings([FromBody] UpdateSettingsRequest req)
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();

        var user = await _db.Users.FindAsync(userId);
        if (user is null) return NotFound();

        user.IsNightMode = req.IsNightMode;
        user.PlayFog = req.PlayFog;

        user.IsRadioEnabled = req.IsRadioEnabled;
        user.RadioVolume = Math.Clamp(req.RadioVolume, 0, 100);

        user.IsRainEnabled = req.IsRainEnabled;
        user.RainVolume = Math.Clamp(req.RainVolume, 0, 100);

        user.IsBirdsEnabled = req.IsBirdsEnabled;
        user.BirdsVolume = Math.Clamp(req.BirdsVolume, 0, 100);

        user.IsWavesEnabled = req.IsWavesEnabled;
        user.WavesVolume = Math.Clamp(req.WavesVolume, 0, 100);

        user.IsThunderEnabled = req.IsThunderEnabled;
        user.ThunderVolume = Math.Clamp(req.ThunderVolume, 0, 100);

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // POST /api/profile/points
    [HttpPost("points")]
    public async Task<IActionResult> AddPoints([FromBody] int pointsToAdd)
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();

        var user = await _db.Users.FindAsync(userId);
        if (user is null) return NotFound();

        user.TotalPoints += pointsToAdd;
        await _db.SaveChangesAsync();

        return Ok(new { user.TotalPoints });
    }

    private int? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(claim, out var id) ? id : null;
    }
}
