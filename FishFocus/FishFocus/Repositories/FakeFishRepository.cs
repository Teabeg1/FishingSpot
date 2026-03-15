using FishFocus.Interfaces;
using FishFocus.Shared.Models;

namespace FishFocus.Repositories;

public class FakeFishRepository : IFishRepository
{
    // типо бд
    private readonly List<Fish> _fakeDb = new()
    {
        new Fish 
        { 
            Name = "Карась обыкновенный", 
            Rarity = 1, 
            Points = 10, 
            ImageUrl = "images/fish/common_carp.png" 
        },
        new Fish 
        { 
            Name = "Красноперка", 
            Rarity = 1, 
            Points = 15, 
            ImageUrl = "images/fish/rudd.png" 
        },
        new Fish 
        { 
            Name = "Зеркальный карп", 
            Rarity = 2, 
            Points = 50, 
            ImageUrl = "images/fish/mirror_carp.png" 
        },
        new Fish 
        { 
            Name = "Синий Марлин", 
            Rarity = 3, 
            Points = 500, 
            ImageUrl = "images/fish/marlin.png" 
        }
    };

    public Task<List<Fish>> GetAllFishesAsync()
    {
        // Итипо задержка
        return Task.FromResult(_fakeDb);
    }
}
