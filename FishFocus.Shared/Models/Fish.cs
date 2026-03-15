namespace FishFocus.Shared.Models;

public class Fish
{
    public string Name { get; set; } = string.Empty;
    public int Rarity { get; set; } // 1 - обычная, 2 - редкая и т.д.
    public int Points { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
