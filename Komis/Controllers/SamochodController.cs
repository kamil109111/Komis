using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Komis.Models;

namespace Komis.Controllers
{
    public class SamochodController : Controller
    {
        private readonly AppDbContext _context;

        public SamochodController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Samochod
        public async Task<IActionResult> Index()
        {
            return View(await _context.Samochody.ToListAsync());
        }

        // GET: Samochod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // GET: Samochod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Samochod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Model,RokProdukcji,Przebieg,Pojemnosc,RodzajPaliwa,Moc,Opis,Cena,ZdjecieUrl,MiniaturkaUrl,JestSamochodemTygodnia,JestWCentrali")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samochod);
        }

        // GET: Samochod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody.FindAsync(id);
            if (samochod == null)
            {
                return NotFound();
            }
            return View(samochod);
        }

        // POST: Samochod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Model,RokProdukcji,Przebieg,Pojemnosc,RodzajPaliwa,Moc,Opis,Cena,ZdjecieUrl,MiniaturkaUrl,JestSamochodemTygodnia,JestWCentrali")] Samochod samochod)
        {
            if (id != samochod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodExists(samochod.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(samochod);
        }

        // GET: Samochod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // POST: Samochod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var samochod = await _context.Samochody.FindAsync(id);
            _context.Samochody.Remove(samochod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodExists(int id)
        {
            return _context.Samochody.Any(e => e.Id == id);
        }
    }
}
