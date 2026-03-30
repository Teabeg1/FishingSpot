namespace FishFocus.Shared.Models;

public class FishCatchResult
{
    public Fish Fish { get; set; } = new();
    public int MinutesFished { get; set; }
    public int BasePoints { get; set; }
    public int TimeBonus { get; set; }
    public int TotalPoints { get; set; }
}
