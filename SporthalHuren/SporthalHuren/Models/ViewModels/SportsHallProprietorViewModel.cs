using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalHuren.Models.Domain;

namespace SporthalHuren.Models.ViewModels
{
    public class SportsHallProprietorViewModel
    {
        public SportsHall Hall { get; set; }
        public IEnumerable<SportsHall> Halls { get; set; }
        public IEnumerable<Proprietor> Proprietors { get; set; }
    }
}
