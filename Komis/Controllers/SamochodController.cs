using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    public class SamochodController : Controller
    {
        private readonly ISamochodRepository _samochodRepository;
        
        // W miejsce ISamochodRepository będzie wstrzykiwania instancja SamochodRepository
        // bo tak jest zadeklarowane w Startup
        public SamochodController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;
        }
        public IActionResult Index()
        {
            // do zmiennej samochody przekazujemy wszystkie samochody
            var samochody = _samochodRepository.PobierzWszystkieSamochody();
            // samochody przekazujemy do widoku
            return View(samochody);

            // którszy zaspis
            // return View(_samochodRepository.PobierzWszystkieSamochody());
        }
    }
}
