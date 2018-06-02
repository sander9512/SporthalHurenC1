using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SporthalHuren.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SporthalHuren.Models.Domain;
using Newtonsoft.Json;

namespace SporthalHuren.Models
{
    public class SportsHall
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "Vul een naam in voor de sporthal")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Vul een telefoonnummer in")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vul een plaatsnaam in")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vul een straatnaam in")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Vul een huisnummer in")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Vul een postcode in")]
        [RegularExpression("^[1-9][0-9]{3} ?[A-Z]{2}", ErrorMessage = ("Voer een geldige Nederlandse postcode in volgens het 1234 AB formaat"))]
        public string Zip { get; set; }
        public int ProprietorID { get; set; }
        [JsonIgnore]
        public virtual Proprietor Proprietor { get; set; }

        public virtual ICollection<OpeningTime> Times { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<SportsHallsActivity> SportsHallActivities { get; set; }
        public virtual ICollection<SportsHallsFacility> SportsHallFacilities { get; set; }

    }
}
