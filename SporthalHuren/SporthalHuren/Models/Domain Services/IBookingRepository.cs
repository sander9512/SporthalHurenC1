using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalHuren.Models;
using SporthalHuren.Models.Domain;

namespace SporthalHuren.Models.Repository
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> Bookings { get; }

        void SaveBooking(Booking booking);
        void EditBooking(Booking Booking);

        void DeleteBooking(int ID);
    }
}
