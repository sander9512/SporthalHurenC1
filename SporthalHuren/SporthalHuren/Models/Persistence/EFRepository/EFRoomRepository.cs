using Microsoft.EntityFrameworkCore;
using SporthalHuren.Models.Domain_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Persistence.EFRepository
{
    public class EFRoomRepository : IRoomRepository
    {
        private ApplicationDbContext context;

        public EFRoomRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Room> Rooms => context.Rooms.Include(x => x.Hall);

        public Room DeleteRoom(int ID)
        {
            Room DbEntry = context.Rooms
           .FirstOrDefault(p => p.ID == ID);
            if (DbEntry != null)
            {
                context.Rooms.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public void EditRoom(Room Room)
        {
            var exists = context.Rooms.Find(Room.ID);
            if (exists != null)
            {
                context.Entry(exists).CurrentValues.SetValues(Room);
            }
            context.SaveChanges();
        }

        public void SaveRoom(Room Room)
        {
            context.Rooms.Add(Room);
            context.SaveChanges();
        }
    }
}
