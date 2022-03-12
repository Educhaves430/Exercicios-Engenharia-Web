using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula11.Models;

namespace Aula11.Data
{
    public class Aula11Context : DbContext
    {
        public Aula11Context (DbContextOptions<Aula11Context> options)
            : base(options)
        {
        }

        public DbSet<Aula11.Models.Person> Person { get; set; }
    }
}
