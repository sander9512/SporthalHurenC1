using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalHuren.Models;
using SporthalHuren.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace SporthalHuren.Models.Repository
{
    public class EFBookingRepository : IBookingRepository
    {
        private ApplicationDbContext context;

        public EFBookingRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Booking> Bookings => context.Bookings.Include(b => b.Hall).ThenInclude(b => b.Rooms).Include(b => b.Hall.Times).Include(b => b.Hall.Proprietor).ThenInclude(b => b.Halls)
            .Include(b => b.Activity).ThenInclude(b => b.SportsHallsActivities).Include(b => b.Hall.SportsHallFacilities);
        

        public void SaveBooking(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }
        public void EditBooking(Booking Booking)
        {
            Booking DbEntry = context.Bookings
                .FirstOrDefault(b => b.ID == Booking.ID);
            if(DbEntry != null)
            {
                DbEntry.Approved = Booking.Approved;
            }
           
            context.SaveChanges();
        }

        public void DeleteBooking(int ID)
        {
            Booking DbEntry = context.Bookings
                .FirstOrDefault(b => b.ID == ID);
            if (DbEntry != null)
            {
                context.Bookings.Remove(DbEntry);
                context.SaveChanges();
            }
        }
    }
}
