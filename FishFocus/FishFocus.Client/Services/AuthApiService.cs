using System.Net.Http.Json;
using FishFocus.Shared.DTOs.Auth;

namespace FishFocus.Client.Services;

public class AuthApiService
{
    private readonly HttpClient _http;

    public AuthApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", request);
        return await response.Content.ReadFromJsonAsync<AuthResponse>();
    }

    public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/register", request);
        return await response.Content.ReadFromJsonAsync<AuthResponse>();
    }

}