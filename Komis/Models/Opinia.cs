using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class Opinia
    {
        public int Id { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Email { get; set; }
        public string Wiadomosc { get; set; }
        public bool OczekujeOdpowiedzi { get; set; }
    }
}
