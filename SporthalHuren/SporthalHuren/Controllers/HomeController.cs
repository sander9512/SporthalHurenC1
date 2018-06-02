using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;
using SporthalHuren.Models.ViewModels;

namespace SporthalHuren.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;
        private ISportshallRepository repository;
        public HomeController(ISportshallRepository repo)
        {
            repository = repo;
        }
        //Staat nu in HallsController
    //    public ViewResult CompareSportsHalls(int sportsHallId, int secondSportsHallId) =>
    //View("ComparedHalls", new CompareHallsViewModel
    //{
    //    SportsHalls = repository.Halls.Where(
    //        h => h.ID != sportsHallId && h.ID != secondSportsHallId
    //        ),
    //    SportsHallId = repository.Halls.FirstOrDefault(
    //        sh => sh.ID == sportsHallId
    //        ),
    //    SecondSportsHallId = repository.Halls.FirstOrDefault(
    //        s => s.ID == secondSportsHallId
    //        )
    //});


        public ViewResult MyAccount()
        {
            return View();
        }

        //public IActionResult Index()

        [HttpPost]
        public ViewResult Index(string InputCity)
        {
            return View("List", new SportsHallViewModel
            {
                SportsHalls = repository.Halls
                .Where(p => p.City.ToUpper().Contains(InputCity.ToUpper()))
                .OrderBy(p => p.Name)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Halls.Count()

                }
            });
 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // repository);
        }


        public IActionResult About()
        {
            ViewData["Why"] = "Waarom Sporthalhuren.nl?";

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
