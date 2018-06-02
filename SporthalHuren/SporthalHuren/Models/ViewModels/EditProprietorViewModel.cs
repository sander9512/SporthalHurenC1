using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class EditProprietorViewModel
    {
        public int ProprietorId { get; set; }
        public Proprietor Proprietor { get; set; }
        public List<SportsHall> Halls { get; set; }
    }
}
