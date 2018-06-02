using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Domain
{
    public class SportsHallsFacility
    {
        public int FacilityID { get; set; }
        public virtual Facility Facility { get; set; }

        public int SportsHallID { get; set; }
        [JsonIgnore]
        public virtual SportsHall Hall { get; set; }
    }
}
