using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Domain_Services
{
    public interface IFacilityRepository
    {
        IEnumerable<Facility> Facilities { get; }
        void SaveFacility(Facility facility);
        void EditFacility(Facility facility);
        Facility DeleteFacility(int ID);
    }
}
