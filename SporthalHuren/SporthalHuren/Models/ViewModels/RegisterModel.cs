using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Voer een e-mail adres in")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Vul een geldig emailadres in")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Voer een telefoonnummer in")]
        [Phone]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Voer een wachtwoord in")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "De opgegeven wachtwoorden komen niet overeen")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; } = "/NormalUser/Index";
    }
}
