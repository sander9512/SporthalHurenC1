using SporthalHuren.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.ViewModels
{
    public class UserBookingViewModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public string CurrentUserID { get; set; }
    }
}
