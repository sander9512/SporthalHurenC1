using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Vul een naam in")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Geef een geboortedatum op")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Vul een emailadres in")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Vul een geldig emailadres in")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul een plaatsnaam in")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vul een straatnaam in")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Vul een huisnummer inclusief toevoeging in")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Vul een postcode in")]
        [RegularExpression("^[1-9][0-9]{3} ?[A-Z]{2}$", ErrorMessage = ("Voer een geldige Nederlandse postcode in volgens het 1234 AB formaat"))]
        public string Zip { get; set; }
    }
}
