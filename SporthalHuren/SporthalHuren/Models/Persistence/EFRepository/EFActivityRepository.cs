using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Repository
{
    public class EFActivityRepository : IActivityRepository
    {
        private ApplicationDbContext context;
        public EFActivityRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Activity> Activities => context.Activities;

        public IEnumerable<string> ActivityNames => context.Activities.Select(x => x.Name).Distinct();

        public Activity DeleteActivity(int ID)
        {
            Activity DbEntry = context.Activities
           .FirstOrDefault(a => a.ID == ID);
            if (DbEntry != null)
            {
                context.Activities.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public void EditActivity(Activity Activity)
        {
            var exists = context.Activities.Find(Activity.ID);
            if (exists != null)
            {
                context.Entry(exists).CurrentValues.SetValues(Activity);
            }
            context.SaveChanges();
        }

        public void SaveActivity(Activity Activity)
        {
            context.Add(Activity);
            context.SaveChanges();
        }
    }
}
