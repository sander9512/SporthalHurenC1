using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace SporthalHuren.Models
{
    public class OpeningTime
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Vul een dag in")]
        public string Day { get; set; }

        [Required(ErrorMessage = "Vul een openingstijd in")]
        public string TimeOpen { get; set; }

        [Required(ErrorMessage = "Vul een sluitingstijd in")]
        public string TimeClose { get; set; }
        public int HallID { get; set; }
        [JsonIgnore]
        public virtual SportsHall Hall { get; set; }
    }
}
