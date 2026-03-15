using FishFocus.Interfaces;
using FishFocus.Shared.Models;

namespace FishFocus.Services;

public class FishingService
{
    private readonly IFishRepository _repository;

    public FishingService(IFishRepository repository)
    {
        _repository = repository; 
    }

    public async Task<Fish> CalculateReward(int minutes)
    {
        var allFish = await _repository.GetAllFishesAsync();
        // чем дольше сидел, тем выше шанс на редкую рыбу
        var random = new Random();
        int chance = random.Next(1, 100) + (minutes / 2); // бонус за время

        if (chance > 90) return allFish.FirstOrDefault(f => f.Rarity == 3) ?? allFish[0];
        if (chance > 60) return allFish.FirstOrDefault(f => f.Rarity == 2) ?? allFish[0];
        return allFish.FirstOrDefault(f => f.Rarity == 1) ?? allFish[0];
    }
}
