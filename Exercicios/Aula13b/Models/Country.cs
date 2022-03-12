using System.ComponentModel.DataAnnotations.Schema;

namespace Aula13a.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Capital { get; set; }

        public string Flag { get; set; }

        [ForeignKey("Continent")]
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
    }
}
