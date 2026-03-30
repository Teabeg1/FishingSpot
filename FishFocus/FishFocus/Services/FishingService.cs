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

    public async Task<FishCatchResult> CalculateReward(int minutes)
    {
        var allFish = await _repository.GetAllFishesAsync();

        var available = allFish.Where(f => f.MinMinutes <= minutes).ToList();

        //если вдруг список пуст (минут 0 и все рыбы закрыты)
        if (available.Count == 0)
            available = allFish.OrderBy(f => f.MinMinutes).Take(1).ToList();

        // чем дольше сидел, тем выше шанс на редкую рыбу
        var random = new Random();
        int chance = random.Next(1, 100) + (minutes / 2); // бонус за время
        Fish caught;

        var legendary = available.Where(f => f.Rarity == 3).ToList();
        var rare = available.Where(f => f.Rarity == 2).ToList();
        var common = available.Where(f => f.Rarity == 1).ToList();

        if (chance > 90 && legendary.Count > 0)
            caught = legendary[random.Next(legendary.Count)];
        else if (chance > 60 && rare.Count > 0)
            caught = rare[random.Next(rare.Count)];
        else
            caught = common.Count > 0
                ? common[random.Next(common.Count)]
                : available[random.Next(available.Count)];

        // Очки: базовые очки рыбы + 10% за каждую минуту ожидания
        // Пример: Карась (10 pts) через 10 мин = 10 * 2.0 = 20 pts
        //         Марлин (500 pts) через 10 мин = 500 * 2.0 = 1000 pts
        double multiplier = 1.0 + (minutes * 0.1);
        int timeBonus = (int)(caught.Points * (multiplier - 1.0));
        int totalPoints = caught.Points + timeBonus;

        return new FishCatchResult
        {
            Fish = caught,
            MinutesFished = minutes,
            BasePoints = caught.Points,
            TimeBonus = timeBonus,
            TotalPoints = totalPoints
        };

    }
}
