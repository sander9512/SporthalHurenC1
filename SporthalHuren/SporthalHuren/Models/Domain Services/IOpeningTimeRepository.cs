using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public interface IOpeningTimeRepository
    {
        IEnumerable<OpeningTime> Times { get; }
        void SaveTime(OpeningTime time);
        void EditTime(OpeningTime time, int id);
        OpeningTime DeleteTime(int ID);
    }
}
