using FishFocus.Interfaces;
using FishFocus.Shared.Models;

namespace FishFocus.Repositories;

public class FakeFishRepository : IFishRepository
{
    private readonly List<Fish> _fakeDb = new()
    {
        new Fish
        {
            Name = "Карась обыкновенный",
            Rarity = 1,
            Points = 10,
            MinMinutes = 1,
            ImageUrl = "/images/fish/common_carp.png"
        },

        new Fish
        {
            Name = "Окунь",
            Rarity = 1,
            Points = 25,
            MinMinutes = 10,
            ImageUrl = "images/fish/perch.png"
        },

        new Fish
        {
            Name = "Красноперка",
            Rarity = 1,
            Points = 50,
            MinMinutes = 30,
            ImageUrl = "images/fish/rudd.png"
        },

        new Fish
        {
            Name = "Язь",
            Rarity = 2,
            Points = 100,
            MinMinutes = 45,
            ImageUrl = "images/fish/ide.png"
        },

        new Fish
        {
            Name = "Зеркальный карп",
            Rarity = 2,
            Points = 200,
            MinMinutes = 60,
            ImageUrl = "images/fish/mirror_carp.png"
        },

        new Fish
        {
            Name = "Щука",
            Rarity = 2,
            Points = 250,
            MinMinutes = 80,
            ImageUrl = "images/fish/pike.png"
        },

        new Fish
        {
            Name = "Сом",
            Rarity = 2,
            Points = 300,
            MinMinutes = 100,
            ImageUrl = "images/fish/catfish.png"
        },

        new Fish
        {
            Name = "Синий Марлин",
            Rarity = 3,
            Points = 500,
            MinMinutes = 120,
            ImageUrl = "images/fish/marlin.png"
        },

    };

    public Task<List<Fish>> GetAllFishesAsync()
    {
        return Task.FromResult(_fakeDb);
    }
}