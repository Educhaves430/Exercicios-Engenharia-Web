using System.Collections.Generic;

namespace Aula13a.Models
{
    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
