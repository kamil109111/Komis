using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    // Ta klasa to pośrednik pomiędzy kodem a bazą danych, dziedziczy po wbudowanym DbContext
    // IdentityUser to klasa która zawiera już podstawowe właściwości
    // które chcemy przechowywać dla użytkownika np. login, email
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
           
        }

        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Opinia> Opinie { get; set; }
    }
}
