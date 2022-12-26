using System.ComponentModel.DataAnnotations;

namespace ButlyaAdmin.ViewModels;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Ім'я користувача")]
    public string Username { get; set; }
    
    [Required]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Display(Name = "Запам'ятати мене")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}