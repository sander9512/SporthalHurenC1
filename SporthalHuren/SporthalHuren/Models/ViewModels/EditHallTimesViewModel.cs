using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class EditHallTimesViewModel
    {
        public int SportsHallId { get; set; }
        public int TimeId { get; set; }
        public List<OpeningTime> Times { get; set; }
    }
}
