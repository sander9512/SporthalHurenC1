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
    [Authorize(Roles ="Administrator")]
    public class AdminProprietorController : Controller
    {
        IProprietorRepository proprietorRepository;
        ISportshallRepository sportsHallRepository;

        public AdminProprietorController(IProprietorRepository proprietorRepo, ISportshallRepository sportsHallRepo)
        {
            sportsHallRepository = sportsHallRepo;
            proprietorRepository = proprietorRepo;
        }

        public IActionResult ProprietorList() =>
            View(proprietorRepository.Proprietors);

        public ViewResult CreateProprietor() =>
            View("EditProprietor", new EditSportsHallFormViewModel());

        [HttpGet]
        public ViewResult EditProprietor(int proprietorId) =>
            View(new EditSportsHallFormViewModel
            {
                Proprietor = proprietorRepository.Proprietors.FirstOrDefault(prop => prop.ID == proprietorId),
                Halls = sportsHallRepository.Halls
            });

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
                else
                {
                    proprietorRepository.SaveProprietor(proprietor);
                }
                return View("ProprietorList", proprietorRepository.Proprietors);
            }
            else
            {
                return View("ProprietorList", proprietorRepository.Proprietors);
            }
        }

        [HttpPost]
        public IActionResult DeleteProprietor(int proprietorId)
        {
            Proprietor deletedProprietor = proprietorRepository.DeleteProprietor(proprietorId);

            return RedirectToAction("ProprietorList");
        }
    }
}
