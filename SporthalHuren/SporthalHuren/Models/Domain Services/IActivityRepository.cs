using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> Activities { get; }

        IEnumerable<string> ActivityNames { get; }

        void SaveActivity(Activity Activity);
        void EditActivity(Activity Activity);

        Activity DeleteActivity(int ID);
    }
}
