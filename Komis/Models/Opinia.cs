using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class Opinia
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string NazwaUzytkownika { get; set; }

        [Required(ErrorMessage = "Adres email jest wymagany")]
        [StringLength(100, ErrorMessage = "Adres email jest za długi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Wiadomość jest wymagana")]
        [StringLength(5000, ErrorMessage ="Wiadomość jest za długa")]
        public string Wiadomosc { get; set; }

        public bool OczekujeOdpowiedzi { get; set; }
    }
}
