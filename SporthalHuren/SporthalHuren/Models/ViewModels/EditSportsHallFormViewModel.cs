using SporthalHuren.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class EditSportsHallFormViewModel
    {
        public int SportsHallId { get; set; }
        public SportsHall Hall { get; set; }
        public IEnumerable<SportsHall> Halls { get; set; }


        public OpeningTime Time { get; set; }
        public IEnumerable<OpeningTime> Times { get; set; }

        public int ProprietorId { get; set; }
        public Proprietor Proprietor { get; set; }
        public IEnumerable<Proprietor> Proprietors { get; set; }

        public Facility Facility { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
        public IEnumerable<SportsHallsActivity> SportsHallActivities { get; set; }
        public IEnumerable<SportsHallsFacility> SportsHallFacilities { get; set; }

        public Room Room { get; set; }
        public IEnumerable<Room> Rooms { get; set; }

    }
}
