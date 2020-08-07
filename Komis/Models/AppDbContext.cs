using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    // Ta klasa to pośrednik pomiędzy kodem a bazą danych, dziedziczy po wbudowanym DbContext
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
           
        }

        public DbSet<Samochod> Samochody { get; set; }
    }
}
