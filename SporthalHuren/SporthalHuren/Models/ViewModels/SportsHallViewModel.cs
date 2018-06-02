using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class SportsHallViewModel
    {
        public IEnumerable<SportsHall> SportsHalls { get; set; }

        public IEnumerable<string> ActivityNames { get; set; }
        
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
