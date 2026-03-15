namespace FishFocus.Shared.Models;

public class Fish
{
    public string Name { get; set; } = "Окунь";
    public int Rarity { get; set; } // 1 - обычная, 2 - редкая и т.д.
    public string ImageUrl { get; set; } = "fish_default.png";
}