using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public class FakeActivityRepository : IActivityRepository
    {
        public IEnumerable<Activity> Activities => new List<Activity>
        {
        new Activity { ID = 1, Name = "Basketbal"},
        new Activity { ID = 2, Name = "Volleybal"},
        new Activity { ID = 3, Name = "Voetbal"},
        new Activity { ID = 4, Name = "Badminton"}
        };

        public IEnumerable<string> ActivityNames => throw new NotImplementedException();

        public Activity DeleteActivity(int ID)
        {
            throw new NotImplementedException();
        }

        public void EditActivity(Activity Activity)
        {
            throw new NotImplementedException();
        }

        public void SaveActivity(Activity Activity)
        {
            throw new NotImplementedException();
        }
    }
}
