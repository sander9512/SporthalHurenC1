using SporthalHuren.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class FakeSportsHallRepository : ISportshallRepository
    {
        private ICollection<Activity> ActivitiesHallOne => new List<Activity> {
        new Activity { ID = 1, Name = "Basketbal"},
        new Activity { ID = 2, Name = "Volleybal"},
        new Activity { ID = 3, Name = "Voetbal"},
        new Activity { ID = 4, Name = "Badminton"}
        };

        private ICollection<Activity> ActivitiesHallTwo => new List<Activity> {
        new Activity { ID = 1, Name = "Basketbal"},
        new Activity { ID = 2, Name = "Volleybal"},
        };

        private ICollection<Room> RoomsHallOne => new List<Room>
        {
            new Room { ID = 1, RoomNumber = "1a"},
            new Room { ID = 2, RoomNumber = "1b"}
        };
        private ICollection<Room> RoomsHallTwo => new List<Room>
        {
            new Room { ID = 1, RoomNumber = "1"},
            new Room { ID = 2, RoomNumber = "2"}
        };

        private ICollection<OpeningTime> Times => new List<OpeningTime>
        {
            new OpeningTime {ID = 1, Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
            new OpeningTime {ID = 1, Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
            new OpeningTime {ID = 1, Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
            new OpeningTime {ID = 1, Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
            new OpeningTime {ID = 1, Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
        };
        private Facility Facility1 = new Facility
        {
            ID = 1,
            Name = "Kantine"
        };
        private Facility Facility2 = new Facility
        {
            ID = 2,
            Name = "Sauna"
        };
        private Facility Facility3 = new Facility
        {
            ID = 3,
            Name = "Douches"
        };

        private ICollection<SportsHallsActivity> SportsHallsActivities => new List<SportsHallsActivity>
        {
            new SportsHallsActivity{ }
        };

        public IEnumerable<SportsHall> Halls => throw new NotImplementedException();


        //public IEnumerable<SportsHall> Halls => new List<SportsHall>
        //{
        //    new SportsHall {ID = 1, City = "Breda", Description = "TestDescription1", HouseNumber = "50", Name = "Sporthal 1",
        //    Rooms = RoomsHallOne, StreetName = "Random Straat 1", Times = Times, Zip = "5423DS", Phone = "3404242423", Activities = ActivitiesHallOne,
        //    Facilities = Facilities},

        //    new SportsHall {ID = 2, City = "Amsterdam", Description = "TestDesc2", HouseNumber = "100", Name = "Sporthal 2",
        //    Rooms = RoomsHallTwo, StreetName = "Random Straat 2", Times = Times, Zip = "4131TT", Phone = "092131542", Activities = ActivitiesHallTwo,
        //    Facilities = Facilities}
        //};

        public SportsHall DeleteHall(int ID)
        {
            throw new NotImplementedException();
        }

        public void SaveSportsHall(SportsHall hall)
        {
            throw new NotImplementedException();
        }

        public void EditSportsHall(SportsHall hall)
        {
            throw new NotImplementedException();
        }

        public SportsHall IsRegistered(SportsHall hall)
        {
            throw new NotImplementedException();
        }

        public SportsHall DeleteHallActivity(int hallId, int activityId)
        {
            throw new NotImplementedException();
        }
    }
}
