namespace FishFocus.Shared.DTOs.Auth;

public class AuthResponse
{
    public bool Success { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int TotalPoints { get; set; }
    public List<string> Errors { get; set; } = new();
}