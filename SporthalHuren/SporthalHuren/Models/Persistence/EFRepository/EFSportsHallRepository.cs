using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Repository
{
    public class EFSportsHallRepository : ISportshallRepository
    {
        private ApplicationDbContext context;

        public EFSportsHallRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SportsHall> Halls => context.Halls
            .Include(g => g.Times).Include(g => g.Proprietor).Include(g => g.Rooms)
            .Include("SportsHallActivities.Activity").Include("SportsHallFacilities.Facility");



        public void SaveSportsHall(SportsHall hall)
        {
            context.Add(hall);
            context.SaveChanges();
        }

        public void EditSportsHall(SportsHall hall)
        {
            SportsHall exists = context.Halls.FirstOrDefault(x => x.ID == hall.ID);

            if (exists != null)
            {
                
                //context.Entry(exists).CurrentValues.SetValues(hall);

                foreach (var time in exists.Times)
                {
                    var originalTime = context.Times.SingleOrDefault(t => t.ID == time.ID);
                    if (originalTime != null)
                    {
                        originalTime.TimeClose = time.TimeClose;
                        originalTime.TimeOpen = time.TimeOpen;
                    }
                }
                context.Halls.Update(exists);
            } 
            context.SaveChanges();
        }

        public SportsHall DeleteHall(int ID)
        {
            SportsHall DbEntry = context.Halls
                .FirstOrDefault(h => h.ID == ID);
            if (DbEntry != null)
            {
                context.Halls.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public SportsHall IsRegistered(SportsHall hall)
        {
            return context.Halls.Find(hall.ID);
        }

        public SportsHall DeleteHallActivity(int hallId, int activityId)
        {
            SportsHall parent = context.Halls.Include(p => p.SportsHallActivities)
                .SingleOrDefault(x => x.ID == hallId);

            foreach (var act in parent.SportsHallActivities.ToList())
            {
                if (act.ActivityID == activityId)
                {
                    context.SportsHallsActivity.Remove(act);
                    context.SaveChanges();
                }
            }
            return parent;
        }
    }
}
