using System.ComponentModel.DataAnnotations;

namespace FishFocus.Shared.DTOs.Auth;

public class RegisterRequest
{
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Имя пользователя обязательно")]
    [MinLength(3, ErrorMessage = "Минимум 3 символа")]
    [MaxLength(30, ErrorMessage = "Максимум 30 символов")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Пароль обязателен")]
    [MinLength(8, ErrorMessage = "Минимум 8 символов")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Подтверждение пароля обязательно")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; } = string.Empty;
}