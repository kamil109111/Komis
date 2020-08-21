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

        //metoda przyjmuje id samochodu
        public IActionResult Details(int id)
        {
            // zmienna samochod przyjmuję wartosc z _samochodRepository o id
            var samochod = _samochodRepository.PobierzSamochodOId(id);

            //sprawdzenie czy samochod został pobrany
            if (samochod == null)
                return NotFound();

            return View(samochod);
        }

        // Ta metoda zwraca widok do dodania nowego samochodu
        public IActionResult Create()
        {
            return View();
        }

        // Ta metoda przyjmuję wartości które zostały wpisane w formularzu create
        [HttpPost]
        // zabezpieczenia przed sfałszowaniem formularza
        [ValidateAntiForgeryToken]
        public IActionResult Create(Samochod samochod)
        {
            // jeśli wszystko ok
            if (ModelState.IsValid)
            {
                _samochodRepository.DodajSamochod(samochod);
                return RedirectToAction("Index");
            }
            // jeśli coś nie tak
            return View(samochod);
        }

        public IActionResult Edit(int Id)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(Id);

            if (samochod == null)
                return NotFound();

            return View(samochod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Samochod samochod)
        {
            // jeśli wszystko ok
            if (ModelState.IsValid)
            {
                _samochodRepository.EdytujSamochod(samochod);
                return RedirectToAction("Index");
            }
            // jeśli coś nie tak
            return View(samochod);
        }

        public IActionResult Delete(int Id)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(Id);
            if (samochod == null)
                return NotFound();

            return View(samochod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(id);
            _samochodRepository.UsunSamochod(samochod);

            return RedirectToAction(nameof(Index));
        }
        
    }
}
