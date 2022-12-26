using System.ComponentModel.DataAnnotations;

namespace ButlyaAdmin.ViewModels;

public class RegisterViewModel
{
    [Required]
    [Display(Name = "Ім'я користувача")]
    public string Username { get; set; }
    
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Паролі не співпадають!")]
    [DataType(DataType.Password)]
    [Display(Name = "Підтвердження паролю")]
    public string PasswordConfirm { get; set; }
}