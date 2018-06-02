using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class FakeUserRepository : IUserRepository
    {
        public IEnumerable<User> Users => new List<User>
        {
            new User
            {
                ID = 0001,
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
                ID = 0002,
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
                ID = 0003,
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
                ID = 0004,
                Name = "Sean Bean",
                Email = "somebean@mail.com",
                StreetName = "Winterlaan",
                HouseNumber = "24a",
                Zip = "5123HO",
                DateOfBirth = new DateTime(1959, 04, 17),
                City = "Breda"
            },
        };

        public User DeleteUser(int ID)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User User)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}
