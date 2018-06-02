using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Domain_Services
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
        void SaveRoom(Room Room);
        void EditRoom(Room Room);
        Room DeleteRoom(int ID);
    }
}
