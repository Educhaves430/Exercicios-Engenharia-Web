using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula8b.Models;

namespace Aula8b.Data
{
    public class Aula8bContext : DbContext
    {
        public Aula8bContext (DbContextOptions<Aula8bContext> options)
            : base(options)
        {
        }

        public DbSet<Aula8b.Models.User> User { get; set; }
    }
}
