using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SporthalHuren.Models.Domain;
using Newtonsoft.Json;

namespace SporthalHuren.Models
{
    public class Facility
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "De faciliteit moet een naam hebben.")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<SportsHallsFacility> SportsHallFacilities { get; set; }
    }
}
