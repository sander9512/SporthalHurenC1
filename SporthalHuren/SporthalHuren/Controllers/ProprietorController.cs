using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;
using SporthalHuren.Models.Repository;
using SporthalHuren.Models.Domain;

namespace SporthalHuren.Controllers
{
    [Authorize(Roles = "Proprietor, Admin")]
    public class ProprietorController : Controller
    {
        private IProprietorRepository ProprietorRepository;
        private IBookingRepository BookingRepository;

        public ProprietorController(IProprietorRepository proprepo, IBookingRepository bookingrepo)
        {
            ProprietorRepository = proprepo;
            BookingRepository = bookingrepo;
        }
        public ViewResult Index()
        {
            return View(ProprietorRepository.Proprietors);
        }

        public ViewResult GetProprietor(int SelectedProprietor)
        {
            IEnumerable<Booking> Bookings = BookingRepository.Bookings.Where(b => b.Hall.Proprietor.ID == SelectedProprietor);
            return View("Bookings", Bookings);
        }

        public IActionResult AcceptBooking(int ID)
        {
            Booking Booking = BookingRepository.Bookings.FirstOrDefault(b => b.ID == ID);
            //1 = Goedgekeurd, 2 = Geweigerd, 0 = In afwachting van goedkeuring
            Booking.Approved = 1;
            BookingRepository.EditBooking(Booking);
            IEnumerable<Booking> Bookings = BookingRepository.Bookings.Where(b => b.Hall.Proprietor.ID == Booking.Hall.Proprietor.ID);
            return View("Bookings", Bookings);
        }

        public IActionResult DenyBooking(int ID)
        {
            Booking Booking = BookingRepository.Bookings.FirstOrDefault(b => b.ID == ID);
            //1 = Goedgekeurd, 2 = Geweigerd, 0 = In afwachting van goedkeuring
            Booking.Approved = 2;
            BookingRepository.EditBooking(Booking);
            IEnumerable<Booking> Bookings = BookingRepository.Bookings.Where(b => b.Hall.Proprietor.ID == Booking.Hall.Proprietor.ID);
            return View("Bookings", Bookings);
        }
    }
}
