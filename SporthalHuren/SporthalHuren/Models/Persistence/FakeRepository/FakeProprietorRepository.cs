using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class FakeProprietorRepository /* : IProprietorRepository*/
    {
        public IEnumerable<Proprietor> Proprietors => new List<Proprietor>
        {
            new Proprietor
            {
                ID = 001,
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
                ID = 002,
                Name = "Adam Sandler",
                Email = "awesome.adam@gmail.com",
                Phone = "0686323409",
                City = "Tilburg",
                StreetName = "Neppestraat",
                HouseNumber = "124b",
                Zip = "5203 RT",
                DateOfBirth = new DateTime(1966, 09, 09)
            }
        };

        public Proprietor DeleteProprietor(int ID)
        {
            throw new NotImplementedException();
        }

        public void SaveProprietor(Proprietor Proprietor)
        {
            throw new NotImplementedException();
        }
    }
}
