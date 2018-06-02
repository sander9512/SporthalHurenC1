using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models.Domain;
using SporthalHuren.Models.ViewModels;
using SporthalHuren.Models.Repository;
using SporthalHuren.Models;
using SporthalHuren.Controllers;
using Microsoft.AspNetCore.Identity;

namespace SporthalHuren.Controllers
{
    [Authorize(Roles = "NormalUser, Administrator")]
    public class NormalUserController : Controller
    {
        public IBookingRepository bookingRepository;
        public ISportshallRepository sportshallRepository;
        public IActivityRepository activityRepository;
        private UserManager<ApplicationUser> userManager;
        public Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public NormalUserController(UserManager<ApplicationUser> _userManager, IBookingRepository _bookingRepository, ISportshallRepository _sportshallRepository, IActivityRepository _activityRepository)
        {
            bookingRepository = _bookingRepository;
            sportshallRepository = _sportshallRepository;
            activityRepository = _activityRepository;
            userManager = _userManager;
            
        }

        public ViewResult Index()
        {
            return View();
        }
        public async Task<ViewResult> MyReservation()
        {
            string CurrentUser = await GetCurrentUserId();
            return View("MyReservation", new UserBookingViewModel
            {
                Bookings = bookingRepository.Bookings.Where(b => b.UserId.Equals(CurrentUser)),
                CurrentUserID = CurrentUser
            });
        }

        public ViewResult CheckReservation(int SelectedBooking)
        {
            ViewData["MijnAccount"] = "Profielgegevens.";
            Booking Booking = bookingRepository.Bookings.SingleOrDefault(b => b.ID == SelectedBooking);
            return View(Booking);
        }

        [HttpGet]
        public ViewResult CreateBooking(int ID)
        {
            return View(new BookingViewModel
            {
                Hall = sportshallRepository.Halls.FirstOrDefault(hall => hall.ID == ID)
            });
        }

        [HttpPost]
        public async Task<ViewResult> CreateBooking(int SelectedActivity, int CurrentSportsHall, int SelectedRoom, Booking booking)
        {

            SportsHall Hall = sportshallRepository.Halls.Where(s => s.ID == CurrentSportsHall).FirstOrDefault();
            booking.Hall = Hall;
            booking.Room = Hall.Rooms.Where(r => r.ID == SelectedRoom).FirstOrDefault();
            booking.Activity = activityRepository.Activities.Where(a => a.ID == SelectedActivity).FirstOrDefault();
            booking.StartTime = booking.Date + booking.StartTime.TimeOfDay;
            booking.EndTime = booking.Date + booking.EndTime.TimeOfDay;
            booking.UserId = await GetCurrentUserId();
            booking.Approved = 0;

            TimeSpan Time = (booking.EndTime.TimeOfDay - booking.StartTime.TimeOfDay);
            booking.RemainingCapacity = GetRemainingCapacity(booking) - booking.Activity.RequiredCapacity;

            if (ModelState.IsValid && !(Time.TotalMinutes <= 30) && (GetRemainingCapacity(booking) >= booking.Activity.RequiredCapacity))
            {
                bookingRepository.SaveBooking(booking);
                return View("Index");
            }
            else
            {
                if(Time.TotalMinutes <= 30)
                {
                    ModelState.AddModelError("Error", "Je moet minimaal 30 minuten reserveren");
                }
                if(GetRemainingCapacity(booking) < booking.Activity.RequiredCapacity)
                {
                    ModelState.AddModelError("Error", "De gekozen zaal is vol op dit tijdstip");
                }
                //Deze check is nu overbodig omdat er ook tijd in capaciteit check zit.
                //if(!CheckTimeSlot(booking))
                //{
                //    ModelState.AddModelError("Error", "Deze tijd is al gereserveerd");
                //}
                return View(new BookingViewModel
                {
                    Hall = booking.Hall
                });
            }

        }

        public int GetRemainingCapacity(Booking Booking)
        {
            int RemainingCapacity = 0;
            if (bookingRepository.Bookings.Any(b => b.Date == Booking.Date && b.Room.ID == Booking.Room.ID))
            {
                IEnumerable<Booking> Bookings = bookingRepository.Bookings.Where(b => b.Date == Booking.Date && b.Room.ID == Booking.Room.ID);
                if (!CheckTimeSlot(Booking))
                {
                    RemainingCapacity = bookingRepository.Bookings.Where(b => b.Date == Booking.Date && b.Room.ID == Booking.Room.ID).Min(b => b.RemainingCapacity);

                }
                if (CheckTimeSlot(Booking))
                {
                    RemainingCapacity = Booking.Hall.Rooms.SingleOrDefault(r => r.ID == Booking.Room.ID).Capacity;
                }
            }
            else
            {
                RemainingCapacity = Booking.Hall.Rooms.SingleOrDefault(r => r.ID == Booking.Room.ID).Capacity;
            }
            return RemainingCapacity;
        }

        public Boolean CheckTimeSlot(Booking Booking)
        {

            IEnumerable<Booking> Bookings = bookingRepository.Bookings.Where(b => b.Date == Booking.Date && b.Room.ID == Booking.Room.ID);
            foreach(var b in Bookings)
            {
                if(Booking.StartTime.TimeOfDay >= b.StartTime.TimeOfDay && Booking.StartTime.TimeOfDay <= b.EndTime.TimeOfDay)
                {
                    return false;
                }
                if (Booking.EndTime.TimeOfDay >= b.StartTime.TimeOfDay && Booking.EndTime.TimeOfDay <= b.EndTime.TimeOfDay)
                {
                    return false;
                }
            }
            return true;
        }


        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            return user?.Id;
        }
    }
}