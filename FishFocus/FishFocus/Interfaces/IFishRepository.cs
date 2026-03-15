using FishFocus.Shared.Models;

namespace FishFocus.Interfaces;

public interface IFishRepository
{
    // из бд рыбы
    Task<List<Fish>> GetAllFishesAsync();
}
