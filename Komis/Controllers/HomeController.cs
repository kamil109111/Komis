using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Komis.ViewModels;
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
            var samochody = _samochodRepository.PobierzWszystkieSamochody().OrderBy(s => s.Marka);

            var homeVM = new HomeViewModel()
            {
                Tytul = "Przegląd Samochodów",
                Samochody = samochody.ToList()
            };

            return View(homeVM);
        }

        // akcja szczegóły która bedzie wyświetlać szczegóły danego samochodu
        public IActionResult Szczegoly(int id)
        {
            // tworzymy zmieną samochod która korzysta z samochodRepository i używa metody PobierzSamochodOId z id samochodu równym id
            var samochod = _samochodRepository.PobierzSamochodOId(id);

            // jeśli nie znajdzie samochodu
            if (samochod == null)

                // zwraca 404
                return NotFound();

            // jeśli znajdzie samochód to zwraca widok
            return View(samochod);

        }
    }
}
