using System.ComponentModel.DataAnnotations;

namespace SporthalHuren.Models.ViewModels
{
    public class LoginModel
    {
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Vul een geldig emailadres in")]
        [EmailAddress]
        [Required(ErrorMessage = "Voer een geldig e-mail adres in")]
        public string Email { get; set; }

        [UIHint("password")]
        [Required(ErrorMessage = "Voer een geldig wachtwoord in")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
