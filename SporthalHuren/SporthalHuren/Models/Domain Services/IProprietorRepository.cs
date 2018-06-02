using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models
{
    public interface IProprietorRepository
    {
        IEnumerable<Proprietor> Proprietors { get; }
        void SaveProprietor(Proprietor Proprietor);
        void EditProprietor(Proprietor Proprietor);
        Proprietor DeleteProprietor(int ID);
        Proprietor IsRegistered(Proprietor Proprietor);
    }
}
