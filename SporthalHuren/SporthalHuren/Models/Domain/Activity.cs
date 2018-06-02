using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SporthalHuren.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class Activity
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public int RequiredCapacity { get; set; }
        [JsonIgnore]
        public virtual ICollection<SportsHallsActivity> SportsHallsActivities { get; set; }
    }
}
