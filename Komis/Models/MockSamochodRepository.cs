﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class MockSamochodRepository : ISamochodRepository
    {
        private List<Samochod> samochody;

        public MockSamochodRepository()
        {
            if (samochody == null)
            {
                ZaladujSamochody();
            }
        }

        private void ZaladujSamochody()
        {
            samochody = new List<Samochod>
            {
            new Samochod { Id = 1, Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = true, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
            new Samochod { Id = 2, Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
            new Samochod { Id = 3, Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
            new Samochod { Id = 4, Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
            new Samochod { Id = 5, Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
            new Samochod { Id = 6, Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" }

            };
        }

        public Samochod PobierzSamochodOId(int samochodId)
        {
            return samochody.FirstOrDefault(s => s.Id == samochodId);
        }

        public IEnumerable<Samochod> PobierzWszystkieSamochody()
        {
            return samochody;
        }

        public void DodajSamochod(Samochod samochod)
        {
            throw new NotImplementedException();
        }

        public void EdytujSamochod(Samochod samochod)
        {
            throw new NotImplementedException();
        }

        public void UsunSamochod(Samochod samochod)
        {
            throw new NotImplementedException();
        }
    }
}
