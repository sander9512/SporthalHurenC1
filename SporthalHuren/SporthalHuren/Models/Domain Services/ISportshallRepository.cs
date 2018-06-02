using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public interface ISportshallRepository
    {
        IEnumerable<SportsHall> Halls { get; }
        void SaveSportsHall(SportsHall hall);
        void EditSportsHall(SportsHall hall);
        SportsHall DeleteHall(int ID);
        SportsHall DeleteHallActivity(int hallId, int activityId);
        SportsHall IsRegistered(SportsHall hall);
    }
}
