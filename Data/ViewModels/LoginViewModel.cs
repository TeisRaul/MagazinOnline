using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Data.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }
    }
}
