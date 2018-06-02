using SporthalHuren.Models.Domain_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Persistence.EFRepository
{
    public class EFFacilityRepository : IFacilityRepository
    {
        private ApplicationDbContext context;

        public EFFacilityRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Facility> Facilities => context.Facilities;

        public Facility DeleteFacility(int ID)
        {
            Facility DbEntry = context.Facilities
           .FirstOrDefault(p => p.ID == ID);
            if (DbEntry != null)
            {
                context.Facilities.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public void EditFacility(Facility facility)
        {
            var exists = context.Facilities.Find(facility.ID);
            if (exists != null)
            {
                context.Entry(exists).CurrentValues.SetValues(facility);
            }
            context.SaveChanges();
        }

        public void SaveFacility(Facility facility)
        {
            context.Facilities.Add(facility);
            context.SaveChanges();
        }
    }
}
