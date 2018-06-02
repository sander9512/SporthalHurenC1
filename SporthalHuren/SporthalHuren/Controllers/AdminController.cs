using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SporthalHuren.Models;
using SporthalHuren.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SporthalHuren.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public ISportshallRepository sportsHallRepository;
        public IProprietorRepository proprietorRepository;
        public IUserRepository userRepository;
        public IOpeningTimeRepository timesRepository;

        public AdminController(ISportshallRepository sportsRepo, IProprietorRepository proprietorRepo,
                IUserRepository userRepo)
        {
            sportsHallRepository = sportsRepo;
            proprietorRepository = proprietorRepo;
            userRepository = userRepo;
        }

        public ViewResult Index() => 
            View(sportsHallRepository.Halls);


        public IActionResult SportsHallList() =>
            View(sportsHallRepository.Halls);

        [HttpGet]
        public ViewResult EditSportsHall(int sportsHallId) =>
            View(new EditSportsHallFormViewModel
            {
                Hall = sportsHallRepository.Halls.FirstOrDefault(hall => hall.ID == sportsHallId),
                Proprietors = proprietorRepository.Proprietors
            });

        [HttpPost]
        public ViewResult EditSportsHall(EditSportsHallFormViewModel viewModel, int SelectedProprietor)
        {


            SportsHall aHall = sportsHallRepository.Halls.FirstOrDefault(x => x.ID == viewModel.Hall.ID);

            Proprietor aProprietor = proprietorRepository.Proprietors.Where(x => x.ID == SelectedProprietor).FirstOrDefault();

            aHall.Proprietor = aProprietor;
            aHall.Name = viewModel.Hall.Name;
            aHall.Description = viewModel.Hall.Description;
            aHall.Phone = viewModel.Hall.Phone;
            aHall.City = viewModel.Hall.City;
            aHall.StreetName = viewModel.Hall.StreetName;
            aHall.HouseNumber = viewModel.Hall.HouseNumber;
            aHall.Zip = viewModel.Hall.Zip;

            if (ModelState.IsValid)
            {
                sportsHallRepository.EditSportsHall(aHall);
                return View("SportsHallList", sportsHallRepository.Halls);
            }
            else
            {
                return View("SportsHallList", sportsHallRepository.Halls);
             }
        }
        
        [HttpPost]
        public ViewResult DeleteSportsHall(int hallId)
        {
            SportsHall deletedHall = sportsHallRepository.DeleteHall(hallId);

            return View("SportsHallList");
        }

        [HttpGet]
        public ViewResult EditHallFacilities(int sportsHallId)
        {
            SportsHall Hall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == sportsHallId);
            EditHallFacilitiesViewModel viewModel = new EditHallFacilitiesViewModel()
            {
                SportsHallId = sportsHallId,
                Facilities = Hall.SportsHallFacilities.ToList(),
            };

            return View("EditHallFacilities", viewModel);
        }

        [HttpPost]
        public ViewResult EditHallFacilities(EditHallFacilitiesViewModel viewModel)
        {
            SportsHall aHall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == viewModel.SportsHallId);

            aHall.SportsHallFacilities = viewModel.Facilities;

            if (ModelState.IsValid)
            {
                sportsHallRepository.EditSportsHall(aHall);
                return View("SportsHallList", sportsHallRepository.Halls);
            }
            else
            {
                return View("SportsHallList", sportsHallRepository.Halls);
            }
        }

        [HttpGet]
        public ViewResult EditHallTimes(int sportsHallId)
        {
            SportsHall Hall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == sportsHallId);
            EditHallTimesViewModel viewModel = new EditHallTimesViewModel()
            {
                SportsHallId = sportsHallId,
                Times = Hall.Times.ToList(),
            };

            return View("EditHallTimes", viewModel);
        }

        [HttpPost]
        public ViewResult EditHallTimes(EditHallTimesViewModel viewModel)
        {
            SportsHall aHall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == viewModel.SportsHallId);

            aHall.Times = viewModel.Times;

            if (ModelState.IsValid)
            {
                sportsHallRepository.EditSportsHall(aHall);
                return View("SportsHallList", sportsHallRepository.Halls);
            }
            else
            {
                return View("SportsHallList", sportsHallRepository.Halls);
            }
        }

        [HttpGet]
        public ViewResult EditHallRooms (int sportsHallId)
        {
            SportsHall aHall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == sportsHallId);
            EditHallRoomsViewModel roomViewModel = new EditHallRoomsViewModel()
            {
                SportsHallId = sportsHallId,
                Rooms = aHall.Rooms.ToList()
            };

            return View("EditHallRooms", roomViewModel);
        }

         [HttpPost]
        public ViewResult EditHallRooms(EditHallRoomsViewModel viewModel)
        {
            SportsHall aHall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == viewModel.SportsHallId);

            aHall.Rooms = viewModel.Rooms;

            if (ModelState.IsValid)
            {
   
                sportsHallRepository.EditSportsHall(aHall);
                return View("SportsHallList", sportsHallRepository.Halls);
            }
            else
            {
                return View("SportsHallList", sportsHallRepository.Halls);
            }
        }

        [HttpGet]
        public ViewResult EditHallActivities(int sportsHallId)
        {
            SportsHall Hall = sportsHallRepository.Halls.FirstOrDefault(h => h.ID == sportsHallId);
            EditHallActivitiesViewModel viewModel = new EditHallActivitiesViewModel()
            {
                SportsHallId = sportsHallId,
                Activities = Hall.SportsHallActivities.ToList(),
            };

            return View("EditHallActivities", viewModel);
        }

        [HttpPost]
        public ViewResult DeleteHallActivity(int hallId, int activityId)
        {

            SportsHall deletedHallActivity = sportsHallRepository.DeleteHallActivity(hallId, activityId);

            return View("SportsHallList");
        }

        public IActionResult ProprietorList() =>
            View(proprietorRepository.Proprietors);

        [HttpGet]
        public ViewResult CreateProprietor() =>
            View("CreateProprietor", new Proprietor());

        [HttpPost]
        public ViewResult CreateProprietor(Proprietor proprietor)
        {
            if (ModelState.IsValid)
            {
                proprietorRepository.SaveProprietor(proprietor);
                return View("ProprietorList", proprietorRepository.Proprietors);
            }
            else
            {
                return View(proprietor);
            }
            
        }


        [HttpGet]
        public ViewResult EditProprietor(int proprietorId) =>
            View(proprietorRepository.Proprietors
                .FirstOrDefault(p => p.ID == proprietorId));
            //View(new EditSportsHallFormViewModel
            //{
            //    Proprietor = proprietorRepository.Proprietors.FirstOrDefault(prop => prop.ID == proprietorId),
            //    Halls = sportsHallRepository.Halls.Where(x => x.Proprietor.ID == proprietorId) 
            //});

        [HttpPost]
        public ViewResult EditProprietor(Proprietor proprietor)
        {
            if (ModelState.IsValid)
            {
                var existing = proprietorRepository.IsRegistered(proprietor) != null;

                if (existing)
                {
                    proprietorRepository.EditProprietor(proprietor);
                }
                return View("ProprietorList", proprietorRepository.Proprietors);
            }
            else
            {
                return View(proprietor);
            } 
            //return View("ProprietorList", proprietorRepository.Proprietors);
        }
        
        [HttpPost]
        public IActionResult DeleteProprietor(int proprietorId)
        {
            Proprietor deletedProprietor = proprietorRepository.DeleteProprietor(proprietorId);

            return RedirectToAction("ProprietorList");
        }


        public IActionResult UserList() =>
            View("UserList", userRepository.Users);

        [HttpGet]
        public ViewResult EditUser(int userId) =>
            View(userRepository.Users
                .FirstOrDefault(user => user.ID == userId));

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.EditUser(user);
                return View("UserList", userRepository.Users);
            }
            else
            {
                return View(user);
            }

            
        }
    }
}
