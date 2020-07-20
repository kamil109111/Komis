using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public interface ISamochodRepository
    {
        // metoda zwracająca listę wszystkich samochodów
        IEnumerable<Samochod> PobierzWszystkieSamochody();

        // metoda zwracjąca samochód o podanym id
        Samochod PobierzSamochodOId(int samochodId);
    }
}
