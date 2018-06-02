using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Repository
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<User> Users => context.Users;

        public User DeleteUser(int ID)
        {
            User DbEntry = context.Users
                .FirstOrDefault(u => u.ID == ID);
            if (DbEntry != null)
            {
                context.Users.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public void EditUser(User User)
        {
            context.Update(User);
            context.SaveChanges();
        }

        public void SaveUser(User User)
        {
            context.Add(User);
            context.SaveChanges();
        }
    }
}
