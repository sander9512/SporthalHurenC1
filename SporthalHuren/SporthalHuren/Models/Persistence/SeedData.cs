using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SporthalHuren.Models.Domain;

namespace SporthalHuren.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Proprietors.Any())
            {
                context.Proprietors.AddRange(
                    new Proprietor
                    {
                        Name = "Ben Stiller",
                        Email = "cool.ben.s@gmail.com",
                        Phone = "0619534876",
                        City = "Breda",
                        StreetName = "Echtestraat",
                        HouseNumber = "106",
                        Zip = "4809 FL",
                        DateOfBirth = new DateTime(1965, 11, 30)
                    },
                    new Proprietor
                    {
                        Name = "Adam Sandler",
                        Email = "awesome.adam@gmail.com",
                        Phone = "0686323409",
                        City = "Tilburg",
                        StreetName = "Neppestraat",
                        HouseNumber = "124b",
                        Zip = "5203 RT",
                        DateOfBirth = new DateTime(1966, 09, 09)
                    }
                 );
                context.SaveChanges();
            }

            if (!context.Activities.Any())
            {
                context.AddRange(
                    new Activity
                    {
                        Name = "Basketbal",
                        RequiredCapacity = 3
                    },
                    new Activity
                    {
                        Name = "Zaalvoetbal",
                        RequiredCapacity = 9
                    },
                    new Activity
                    {
                        Name ="Zaalhockey",
                        RequiredCapacity = 9
                    },
                    new Activity
                    {
                        Name ="Volleybal",
                        RequiredCapacity = 2
                    
                    },
                    new Activity
                    {
                        Name ="Badminton",
                        RequiredCapacity = 1
                    }
                        );
                context.SaveChanges();
            }

            if (!context.Facilities.Any())
            {
                context.AddRange(
                    new Facility
                    {
                        Name ="Kluis"
                    },
                    new Facility
                    {
                        Name ="Douche"
                    },
                    new Facility
                    {
                        Name="Kantine"
                    },
                    new Facility
                    {
                        Name ="Kleedkamer"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Halls.Any())
            {
                context.AddRange(
                    new SportsHall
                    {
                        City = "Breda",
                        Description = "In deze sporthal zijn er douches aanwezig. De afmeting van de gymzaal is 20 bij 12 meter. " +
                        "Er is een tribune, scorebord en geluidsinstallatie. Tevens is er een horeca gelegenheid aanwezig",
                        HouseNumber = "50",
                        Name = "BreeSport",
                        Rooms = new List<Room>
                        {
                            new Room { RoomNumber = "1a", Capacity = 9},
                            new Room { RoomNumber = "1b", Capacity = 9}
                        },
                        StreetName = "Oranjeboomstraat",
                        Times = new List<OpeningTime>
                  {
                       new OpeningTime {Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
                   },
                        Zip = "5423DS",
                        Phone = "0644110045",
                        Proprietor = context.Proprietors.Where(p => p.Name.Contains("Ben")).FirstOrDefault()
                      
                        
                    },
                    new SportsHall
                    {
                        City = "Amsterdam",
                        Description = "In deze sporthal zijn er douches aanwezig. De afmeting van de gymzaal is 20 bij 12 meter. " +
                        "Er is een tribune, scorebord en geluidsinstallatie. Tevens is er een horeca gelegenheid aanwezig",
                        HouseNumber = "100",
                        Name = "SporthalLife",
                        Rooms = new List<Room>
                        {
                            new Room {RoomNumber = "1", Capacity = 9},
                            new Room {RoomNumber = "2", Capacity = 9}
                        },
                        StreetName = "Princes Albert Clauslaan",
                        Times = new List<OpeningTime>
                        {
                       new OpeningTime {Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
                        },
                        Zip = "4131TT",
                        Phone = "0675120466",
                        Proprietor = context.Proprietors.Where(p => p.Name.Contains("Ben")).FirstOrDefault()
                    },
                    new SportsHall
                    {
                        City = "Breda",
                        Description = "In deze sporthal zijn er douches aanwezig. De afmeting van de gymzaal is 20 bij 12 meter. " +
                        "Er is een tribune, scorebord en geluidsinstallatie. Tevens is er een horeca gelegenheid aanwezig",
                        HouseNumber = "9",
                        Name = "Bressport",
                        Rooms = new List<Room>
                        {
                            new Room {RoomNumber = "Zaal 1", Capacity = 9},
                            new Room {RoomNumber = "Zaal 2", Capacity = 9}
                        },
                        StreetName = "Bavelselaan",
                        Times = new List<OpeningTime>
                        {
                       new OpeningTime {Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
                        },
                        Zip = "5343AA",
                        Phone = "064334234",
                        Proprietor = context.Proprietors.Where(p => p.Name.Contains("Ben")).FirstOrDefault()
                    },
                    new SportsHall
                    {
                        City = "Amsterdam",
                        Description = "In deze sporthal zijn er douches aanwezig. De afmeting van de gymzaal is 20 bij 12 meter. " +
                        "Er is een tribune, scorebord en geluidsinstallatie. Tevens is er een horeca gelegenheid aanwezig",
                        HouseNumber = "23",
                        Name = "Sporthal Rembrandt",
                        Rooms = new List<Room>
                        {
                            new Room {RoomNumber = "Zaal 1A", Capacity = 9},
                            new Room {RoomNumber = "Zaal 1B", Capacity = 9}
                        },
                        StreetName = "Akersingel",
                        Times = new List<OpeningTime>
                        {
                       new OpeningTime {Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
                        },
                        Zip = "3423YT",
                        Phone = "0612556631",
                        Proprietor = context.Proprietors.Where(p => p.Name.Contains("Adam")).FirstOrDefault()
                    },
                    new SportsHall
                    {
                        City = "Tilburg",
                        Description = "In deze sporthal zijn er douches aanwezig. De afmeting van de gymzaal is 20 bij 12 meter. " +
                        "Er is een tribune, scorebord en geluidsinstallatie. Tevens is er een horeca gelegenheid aanwezig",
                        HouseNumber = "10",
                        Name = "Poelmeerse Sporthal",
                        Rooms = new List<Room>
                        {
                            new Room {RoomNumber = "Zaal 10", Capacity = 9},
                            new Room {RoomNumber = "Zaal 11", Capacity = 9}
                        },
                        StreetName = "Buitenstraat",
                        Times = new List<OpeningTime>
                        {
                       new OpeningTime {Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
                        },
                        Zip = "3422AD",
                        Phone = "063423442",
                        Proprietor = context.Proprietors.Where(p => p.Name.Contains("Adam")).FirstOrDefault()

                    },
                    new SportsHall
                    {
                        City = "Tilburg",
                        Description = "In deze sporthal zijn er douches aanwezig. De afmeting van de gymzaal is 20 bij 12 meter." +
                        "Er is een tribune, scorebord en geluidsinstallatie. Tevens is er een horeca gelegenheid aanwezig",
                        HouseNumber = "11",
                        Name = "Tillie Sportfit",
                        Rooms = new List<Room>
                        {
                            new Room {RoomNumber = "Zaal 1", Capacity = 9}
                        },
                        StreetName = "Columbusplein",
                        Times = new List<OpeningTime>
                        {
                       new OpeningTime {Day = "Maandag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Dinsdag", TimeOpen = "8:00", TimeClose = "22:00"},
                       new OpeningTime {Day = "Woensdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Donderdag", TimeOpen = "8:00", TimeClose = "22:30"},
                       new OpeningTime {Day = "Vrijdag", TimeOpen = "9:00", TimeClose = "21:00"},
                        },
                        Zip = "1315ST",
                        Phone = "063423424",
                        Proprietor = context.Proprietors.Where(p => p.Name.Contains("Adam")).FirstOrDefault()

                    }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.AddRange(
                     new User
                     {
                         Name = "Rob Schneider",
                         Email = "carrot.rob@gmail.com",
                         StreetName = "Voorbeeldstraat",
                         HouseNumber = "18c",
                         Zip = "4809AC",
                         DateOfBirth = new DateTime(1963, 10, 31),
                         City = "Tilburg"
                     },
                    new User
                    {
                        Name = "Tommy Wiseau",
                        Email = "wiseautime@mail.com",
                        StreetName = "Ergenslaan",
                        HouseNumber = "7",
                        Zip = "4414GD",
                        DateOfBirth = new DateTime(1968, 10, 03),
                        City = "Breda"
                    },
                    new User
                    {
                        Name = "Owen Wilson",
                        Email = "owenhanselwilson@mail.com",
                        StreetName = "Hoofdstraat",
                        HouseNumber = "12",
                        Zip = "4773BE",
                        DateOfBirth = new DateTime(1968, 11, 18),
                        City = "Tilburg"
                    },
                    new User
                    {
                        Name = "Sean Bean",
                        Email = "somebean@mail.com",
                        StreetName = "Winterlaan",
                        HouseNumber = "24a",
                        Zip = "5123HO",
                        DateOfBirth = new DateTime(1959, 04, 17),
                        City = "Breda"
                    }
                    );
                context.SaveChanges();
            }
            if (!context.SportsHallsActivity.Any())
            {
                context.AddRange(
                      new SportsHallsActivity
                      {
                        Activity = context.Activities.Where(x => x.ID == 1).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                      },
                      new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 2).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                       },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 3).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                       },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 4).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                       },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 5).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                      },
                      new SportsHallsActivity
                      {
                          Activity = context.Activities.Where(x => x.ID == 1).FirstOrDefault(),
                          Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                      },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 3).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                       },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 4).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                       },
                        new SportsHallsActivity
                        {
                            Activity = context.Activities.Where(x => x.ID == 1).FirstOrDefault(),
                            Hall = context.Halls.Where(x => x.ID == 3).FirstOrDefault()
                        },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 3).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 3).FirstOrDefault()
                       },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 4).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 3).FirstOrDefault()
                       },
                        new SportsHallsActivity
                        {
                            Activity = context.Activities.Where(x => x.ID == 4).FirstOrDefault(),
                            Hall = context.Halls.Where(x => x.ID == 4).FirstOrDefault()
                        },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 5).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 4).FirstOrDefault()
                       },
                      new SportsHallsActivity
                      {
                          Activity = context.Activities.Where(x => x.ID == 1).FirstOrDefault(),
                          Hall = context.Halls.Where(x => x.ID == 4).FirstOrDefault()
                      },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 1).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                       },
                      new SportsHallsActivity
                      {
                          Activity = context.Activities.Where(x => x.ID == 2).FirstOrDefault(),
                          Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                      },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 3).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                       },
                        new SportsHallsActivity
                        {
                            Activity = context.Activities.Where(x => x.ID == 4).FirstOrDefault(),
                            Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                        },
                       new SportsHallsActivity
                       {
                           Activity = context.Activities.Where(x => x.ID == 5).FirstOrDefault(),
                           Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                       },
                      new SportsHallsActivity
                      {
                          Activity = context.Activities.Where(x => x.ID == 1).FirstOrDefault(),
                          Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                      }
                    );
                context.SaveChanges();
            }
            if (!context.SportsHallsFacility.Any())
            {
                context.AddRange(
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 1).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 2).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 3).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 4).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 1).FirstOrDefault()
                    },
                    new SportsHallsFacility
                     {
                         Facility = context.Facilities.Where(x => x.ID == 2).FirstOrDefault(),
                         Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                     },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 3).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 4).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 2).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                         Facility = context.Facilities.Where(x => x.ID == 3).FirstOrDefault(),
                         Hall = context.Halls.Where(x => x.ID == 3).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 4).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 3).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 2).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 3).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 3).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 4).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 4).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 4).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 2).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 4).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                         Facility = context.Facilities.Where(x => x.ID == 1).FirstOrDefault(),
                         Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 2).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 3).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 4).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 5).FirstOrDefault()
                    },
                     new SportsHallsFacility
                     {
                         Facility = context.Facilities.Where(x => x.ID == 1).FirstOrDefault(),
                         Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                     },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 2).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 3).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                    },
                    new SportsHallsFacility
                    {
                        Facility = context.Facilities.Where(x => x.ID == 4).FirstOrDefault(),
                        Hall = context.Halls.Where(x => x.ID == 6).FirstOrDefault()
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
