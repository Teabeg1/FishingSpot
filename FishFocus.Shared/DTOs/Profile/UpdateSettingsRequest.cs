namespace FishFocus.Shared.DTOs.Profile;

public class UpdateSettingsRequest
{
    // Визуальные настройки
    public bool IsNightMode { get; set; }
    public bool PlayFog { get; set; }

    // Радио
    public bool IsRadioEnabled { get; set; }
    public int RadioVolume { get; set; }

    // Дождь
    public bool IsRainEnabled { get; set; }
    public int RainVolume { get; set; }

    // Птицы
    public bool IsBirdsEnabled { get; set; }
    public int BirdsVolume { get; set; }

    // Волны
    public bool IsWavesEnabled { get; set; }
    public int WavesVolume { get; set; }

    // Гром
    public bool IsThunderEnabled { get; set; }
    public int ThunderVolume { get; set; }
}
