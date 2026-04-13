using System.ComponentModel.DataAnnotations;
namespace FishFocus.Shared.Models;

public class FishCatchResult
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public Fish Fish { get; set; } = new();
    public int MinutesFished { get; set; }
    public int BasePoints { get; set; }
    public int TimeBonus { get; set; }
    public int TotalPoints { get; set; }
}
