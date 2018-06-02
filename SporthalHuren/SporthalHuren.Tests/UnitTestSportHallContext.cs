using SporthalHuren.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SporthalHuren.Models.Domain;
using Moq;

namespace SporthalHuren.Tests
{
    public class UnitTestSportHallContext
    {
        public Mock<ISportshallRepository> Repo { get; set; }

        public UnitTestSportHallContext()
        {
            Repo = new Mock<ISportshallRepository>();
            Repo.Setup(s => s.Halls).Returns(new[] { new SportsHall
                    {
                        ID = 1,
                        City = "Breda",
                        Description = "TestDescription1",
                        HouseNumber = "50",
                        Name = "Sporthal A",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a"},
                            new Room { RoomNumber = "1b"}
                        },
                        StreetName = "Random Straat 1",
                        Zip = "5423DS",
                        Phone = "3404242423",
                        SportsHallActivities = new List<SportsHallsActivity>
                        {
                            new SportsHallsActivity { Activity = new Activity{Name = "Zaalvoetbal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Volleybal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Basketbal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Badminton"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Zaalhockey"} }
                        },
                        SportsHallFacilities = new List<SportsHallsFacility>
                        {
                            new SportsHallsFacility { Facility = new Facility{Name = "Kantine"} },
                            new SportsHallsFacility { Facility = new Facility{Name = "Douche"} },
                        }
                    },
                    new SportsHall
                    {
                        ID = 2,
                        City = "Breda",
                        Description = "TestDescription1",
                        HouseNumber = "50",
                        Name = "Sporthal B",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a"},
                            new Room { RoomNumber = "1b"}
                        },
                        StreetName = "Random Straat 1",
                        Zip = "5423DS",
                        Phone = "3404242423",
                        SportsHallActivities = new List<SportsHallsActivity>
                        {
                            new SportsHallsActivity { Activity = new Activity{Name = "Basketbal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Badminton"} },
                        }
                    },
                    new SportsHall
                    {
                        ID = 3,
                        City = "Amsterdam",
                        Description = "TestDescription1",
                        HouseNumber = "50",
                        Name = "Sporthal C",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a"},
                            new Room { RoomNumber = "1b"}
                        },
                        StreetName = "Random Straat 1",
                        Zip = "5423DS",
                        Phone = "3404242423",
                        SportsHallActivities = new List<SportsHallsActivity>
                        {
                            new SportsHallsActivity { Activity = new Activity{Name = "Volleybal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Basketbal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Zaalhockey"} }
                        }
                     },
                      new SportsHall
                    {
                        ID = 4,
                        City = "Amsterdam",
                        Description = "TestDescription1",
                        HouseNumber = "50",
                        Name = "Sporthal D",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a"},
                            new Room { RoomNumber = "1b"}
                        },
                        StreetName = "Random Straat 1",
                        Zip = "5423DS",
                        Phone = "3404242423",
                        SportsHallActivities = new List<SportsHallsActivity>
                        {
                            new SportsHallsActivity { Activity = new Activity{Name = "Volleybal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Zaalhockey"} }
                        }
                     },
                        new SportsHall
                    {
                        ID = 5,
                        City = "Tilburg",
                        Description = "TestDescription1",
                        HouseNumber = "50",
                        Name = "Sporthal E",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a"},
                            new Room { RoomNumber = "1b"}
                        },
                        StreetName = "Random Straat 1",
                        Zip = "5423DS",
                        Phone = "3404242423",
                        SportsHallActivities = new List<SportsHallsActivity>
                        {
                            new SportsHallsActivity { Activity = new Activity{Name = "Volleybal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Basketbal"} },                         
                        }
                     },
                          new SportsHall
                    {
                        ID = 6,
                        City = "Tilburg",
                        Description = "TestDescription1",
                        HouseNumber = "50",
                        Name = "Sporthal F",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a"},
                            new Room { RoomNumber = "1b"}
                        },
                        StreetName = "Random Straat 1",
                        Zip = "5423DS",
                        Phone = "3404242423",
                        SportsHallActivities = new List<SportsHallsActivity>
                        {
                            new SportsHallsActivity { Activity = new Activity{Name = "Volleybal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Basketbal"} },
                            new SportsHallsActivity { Activity = new Activity{Name = "Zaalhockey"} }
                        }
                     }
            });
        }
    }
}
