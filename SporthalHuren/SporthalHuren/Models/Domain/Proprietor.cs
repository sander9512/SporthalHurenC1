using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SporthalHuren.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace SporthalHuren.Models
{
    public class Proprietor
    {
        [BindNever]
        public int ID { get; set; }

        [Required(ErrorMessage = "Voer een volledige naam in.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul een emailadres in")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Vul een geldig emailadres in")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul een telefoonnummer in")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vul een plaatsnaam in")]
        public string City { get; set; }

        [Required(ErrorMessage = "Voer een huisnummer in")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Vul een plaatsnaam in")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Vul een postcode in")]
        [RegularExpression("^[1-9][0-9]{3} ?[A-Z]{2}$", ErrorMessage = ("Voer een geldige Nederlandse postcode in volgens het 1234 AB formaat"))]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Vul een geboortedatum in")]
        public DateTime DateOfBirth { get; set; }
        [JsonIgnore]
        public virtual ICollection<SportsHall> Halls { get; set; }
    }
}
