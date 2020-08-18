using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    [Authorize]
    public class OpiniaController : Controller
    {
        private readonly IOpiniaRepository _opiniaRepository;

        public OpiniaController(IOpiniaRepository opiniaRepository)
        {
            _opiniaRepository = opiniaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // ta metoda działania ma byc wywoływana gdy wysyłamy żądanie post do kontrolera
        // z form w widoku opini index
        [HttpPost]
        // 1 dostajemy opinie z formularza
        public IActionResult Index(Opinia opinia)
        {
            //jeśli walidacja ModelState jest poprawna
            if (ModelState.IsValid)
            {
                // 2 dodajemy opinie do bazy
                _opiniaRepository.DodajOpinie(opinia);

                //przekierowujemy uzytkownika do innej akcji żeby mu podziękować za dodanie opini
                return RedirectToAction("OpiniaWyslana");
            }
            // jeśli Walidacja ModelState jest nie poprawna
            // użytkownik zobaczy ten sam widok z error messages
            return View(opinia);

        }

        public IActionResult OpiniaWyslana()
        {
            return View();
        }
    }
}
