namespace FishFocus.Shared.Models;

public class Fish
{
    public string Name { get; set; } = string.Empty;
    public int Rarity { get; set; }
    public int Points { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int MinMinutes { get; set; } = 0;
}
