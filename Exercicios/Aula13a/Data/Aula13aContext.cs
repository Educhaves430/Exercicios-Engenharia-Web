using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula13a.Models;

namespace Aula13a.Data
{
    public class Aula13aContext : DbContext
    {
        public Aula13aContext (DbContextOptions<Aula13aContext> options)
            : base(options)
        {
        }

        public DbSet<Aula13a.Models.Continent> Continent { get; set; }

        public DbSet<Aula13a.Models.Country> Country { get; set; }
    }
}
