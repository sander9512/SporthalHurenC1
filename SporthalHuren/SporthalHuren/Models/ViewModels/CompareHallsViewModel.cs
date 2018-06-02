using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class CompareHallsViewModel
    {
        public IEnumerable<SportsHall> SportsHalls { get; set; }

        public SportsHall SportsHallId { get; set; }

        public SportsHall SecondSportsHallId { get; set; }
    }
}
