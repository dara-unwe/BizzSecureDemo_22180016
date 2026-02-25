using System.ComponentModel.DataAnnotations;
namespace BizzSecureDemo_22180016.ViewModels;
public class LoginVm
{
    [Required, EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
}