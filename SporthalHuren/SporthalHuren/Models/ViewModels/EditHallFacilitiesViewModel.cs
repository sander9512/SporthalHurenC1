using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class EditHallFacilitiesViewModel
    {
        public int SportsHallId { get; set; }
        public List<Domain.SportsHallsFacility> Facilities { get; set; }
    }
}
