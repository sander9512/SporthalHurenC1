using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Repository
{
    public class EFOpeningTimeRepository : IOpeningTimeRepository
    {
        private ApplicationDbContext context;

        public EFOpeningTimeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<OpeningTime> Times => context.Times;

        public void SaveTime(OpeningTime time)
        {
            context.Times.Add(time);
            context.SaveChanges();
        }

        public void EditTime(OpeningTime time, int id)
        {
            var exists = context.Times.Find(id);
            if (exists != null)
            {
                context.Update(time);
            }
            context.SaveChanges();
        }

        public OpeningTime DeleteTime(int ID)
        {
            OpeningTime DbEntry = context.Times
                .FirstOrDefault(t => t.ID == ID);
            if (DbEntry != null)
            {
                context.Times.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }
    }
}
