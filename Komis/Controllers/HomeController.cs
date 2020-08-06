using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    // HomeController jest klasą która dziedziczy po klasie podstawowej Controller
    // Controller powinien mieć nazwę kończącą się na Controller 
    public class HomeController : Controller
    {
        private readonly ISamochodRepository _samochodRepository;
        
        // konstruktor 
        // Kiedy jest tworzony HomeController to chcemy żeby był do niego przekazywany ISamochodrepository

        public HomeController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;

        }

        public IActionResult Index()
        {
            ViewBag.Tytul = "Przegląd Samochodów";

            var samochody = _samochodRepository.PobierzWszystkieSamochody().OrderBy(s => s.Marka);


            return View(samochody);
        }
    }
}
