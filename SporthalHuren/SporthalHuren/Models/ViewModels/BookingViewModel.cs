using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalHuren.Models.Domain;

namespace SporthalHuren.Models.ViewModels
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public SportsHall Hall { get; set; }
        public int ActivityId { get; set; }
        public int SportsHallId { get; set; }
        public int RoomId { get; set; }


        //public int ID { get; set; }
        //public int UserID { get; set; }
        //public SportsHall Hall { get; set; }
        //public DateTime Datetime { get; set; }
        //public Activity Activity { get; set; }
        //public Room Room { get; set; }
        //public Boolean Approved { get; set; }
        //public int RemainingCapacity { get; set; }

    }
}
