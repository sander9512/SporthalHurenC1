using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Domain
{
    public class SportsHallsActivity
    {
        public int ActivityID { get; set; }
        public virtual Activity Activity { get; set; }

        public int SportsHallID { get; set; }
        [JsonIgnore]
        public virtual SportsHall Hall { get; set; }
    }
}
