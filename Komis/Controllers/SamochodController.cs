using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    public class SamochodController : Controller
    {
        private readonly ISamochodRepository _samochodRepository;

        // dostęp do zmiennych środowiskowych wwwroot
        private IHostingEnvironment _env;
        
        // W miejsce ISamochodRepository będzie wstrzykiwania instancja SamochodRepository
        // bo tak jest zadeklarowane w Startup
        public SamochodController(ISamochodRepository samochodRepository, IHostingEnvironment env)
        {
            _samochodRepository = samochodRepository;
            _env = env;
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
        public IActionResult Create(string FileName)
        {
            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;

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

        public IActionResult Edit(int Id, string FileName)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(Id);

            if (samochod == null)
                return NotFound();

            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            else
                ViewBag.ImgPath = samochod.ZdjecieUrl;

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

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormCollection form)
        {
            var webRoot = _env.WebRootPath;
            var filePath = Path.Combine(webRoot.ToString() + "\\images\\" + form.Files[0].FileName);

            //sprawdzamy czy plik istnieje
            if (form.Files[0].FileName.Length>0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.Files[0].CopyToAsync(stream);
                }
            }

            //sprawdzamy czy przychodzimy z widoku Create czy Edit
            // jeśli string będzie pusty to wiemy że przychodzimy z create
            // bo samochod nie ma jeszce nadanego id
            if (Convert.ToString(form["Id"])== string.Empty || Convert.ToString(form["Id"]) == "0")
                // przekierowanie do akcji Create
                    return RedirectToAction(nameof(Create), new { FileName = Convert.ToString(form.Files[0].FileName) });

            // w przeciwny razie przekierowujemy do akcji Edit
            return RedirectToAction(nameof(Edit), new { FileName = Convert.ToString(form.Files[0].FileName), id = Convert.ToString(form["Id"]) });

        }
        
    }
}
