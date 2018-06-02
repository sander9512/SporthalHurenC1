using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SporthalHuren.Models;
using SporthalHuren.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Controllers
{
    public class HallsController : Controller
    {
        private ISportshallRepository repository;
        private IActivityRepository arepository;
        int PageSize = 6;
       // const string SessionKey = "_Halls";

        public HallsController(ISportshallRepository repo, IActivityRepository aRepo)
        {
            repository = repo;
            arepository = aRepo;
        }

        public ViewResult Filter(string SelectedSport = "", string SelectedLocation = "", int SortBy = 0, int page = 1)
        {
            List<SportsHall> Halls = repository.Halls.ToList();
            if (SelectedSport != null && SelectedSport != "")
                Halls = Halls.Where(e => e.SportsHallActivities.Count(c => c.Activity.Name.ToLower() == SelectedSport.ToLower()) > 0).ToList();
            if (SelectedLocation != null && SelectedLocation != "")
                Halls = Halls.Where(e => e.City.ToLower().Contains(SelectedLocation.ToLower())).ToList();

            Halls = SortBy == 0 ? Halls.OrderBy(e => e.Name).ToList() : Halls.OrderByDescending(e => e.Name).ToList();

            ViewBag.City = SelectedLocation;
            ViewBag.Sport = SelectedSport;

            //List<int> HallIds = new List<int>();
            //for(int i = 0; i < Halls.Count(); i++)
            //{
            //    HallIds.Add(Halls.ElementAt(i).ID);
            //}
            //var Objects = JsonConvert.SerializeObject(HallIds);
            //HttpContext.Session.SetString(SessionKey, Objects);
            

            return View("Filter", new SportsHallViewModel
            {
                SportsHalls = Halls
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                ActivityNames = arepository.ActivityNames,
               PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                    repository.Halls.Count()

                }
            });
        }
        public ViewResult CompareSportsHalls(int sportsHallId, int secondSportsHallId)
        {
            //var Key = HttpContext.Session.GetString(SessionKey);
            //List<int> HallIds = JsonConvert.DeserializeObject<List<int>>(Key);

            //List<SportsHall> FilteredHalls = new List<SportsHall>();
            //for(int i = 0; i < HallIds.Count(); i++)
            //{
            //    SportsHall Hall = repository.Halls.FirstOrDefault(s => s.ID == HallIds.ElementAt(i));
            //    FilteredHalls.Add(Hall);
            //}
            return View("ComparedHalls", new CompareHallsViewModel
            {
                SportsHalls = repository.Halls.Where(
                h => h.ID != sportsHallId && h.ID != secondSportsHallId
                ),
                //SportsHalls = FilteredHalls.Where(
                //    h => h.ID != sportsHallId && h.ID != secondSportsHallId),
                SportsHallId = repository.Halls.FirstOrDefault(
                sh => sh.ID == sportsHallId
                ),
                SecondSportsHallId = repository.Halls.FirstOrDefault(
                s => s.ID == secondSportsHallId
                )
            });
        }
        public ViewResult Hall(int ID)
        {
            SportsHall Hall = repository.Halls.Where(x => x.ID == ID).FirstOrDefault();
            return View("Hall", Hall);
        }
    }

}
