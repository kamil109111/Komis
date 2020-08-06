using Komis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.ViewModels
{
    public class HomeViewModel
    {
        public string Tytul { get; set; }
        public List<Samochod> Samochody { get; set; }
    }
}
