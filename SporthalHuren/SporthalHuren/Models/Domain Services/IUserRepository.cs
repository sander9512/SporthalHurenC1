using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void SaveUser(User User);
        void EditUser(User User);
        User DeleteUser(int ID);
    }
}
