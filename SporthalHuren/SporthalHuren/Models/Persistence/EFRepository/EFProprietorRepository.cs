using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Repository
{
    public class EFProprietorRepository : IProprietorRepository
    {
        private ApplicationDbContext context;

        public EFProprietorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Proprietor> Proprietors => context.Proprietors.Include(p => p.Halls);

        public void SaveProprietor(Proprietor Proprietor)
        {
            context.Proprietors.Add(Proprietor);
            context.SaveChanges();
            //    Proprietor dbEntry = context.Proprietors
            //        .FirstOrDefault(p => p.ID == Proprietor.ID);
            //    if (dbEntry != null)
            //    {
            //        dbEntry.Name = Proprietor.Name;
            //        dbEntry.Email = Proprietor.Email;
            //        dbEntry.Phone = Proprietor.Phone;
            //        dbEntry.City = Proprietor.City;
            //        dbEntry.StreetName = Proprietor.StreetName;
            //        dbEntry.HouseNumber = Proprietor.HouseNumber;
            //        dbEntry.Zip = Proprietor.Zip;
            //        dbEntry.DateOfBirth = Proprietor.DateOfBirth;
            //    }
            //}
        }

        public void EditProprietor(Proprietor proprietor)
        {
            var exists = context.Proprietors.Find(proprietor.ID);
            if(exists != null)
            {
                context.Entry(exists).CurrentValues.SetValues(proprietor);
            }
            context.SaveChanges();
        }

        public Proprietor DeleteProprietor(int ID)
        {
            Proprietor DbEntry = context.Proprietors
            .FirstOrDefault(p => p.ID == ID);
            if (DbEntry != null)
            {
                context.Proprietors.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public Proprietor IsRegistered(Proprietor proprietor)
        {
            return context.Proprietors.Find(proprietor.ID);
        }
    }
}
