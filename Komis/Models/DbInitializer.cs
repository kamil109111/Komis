using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Samochody.Any())
            {
                context.AddRange(
                    new Samochod {Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = true, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
                    new Samochod {Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
                    new Samochod {Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
                    new Samochod {Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" },
                    new Samochod {Marka = "Ford", Model = "Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa = "Benzyna", Moc = "350 KM", JestSamochodemTygodnia = false, Opis = "Ford Mustang", Cena = 50000, MiniaturkaUrl = "/images/mustang.jpg", ZdjecieUrl = "/images/mustang.jpg" }
                    );
            }
            context.SaveChanges();
        }
    }
}
