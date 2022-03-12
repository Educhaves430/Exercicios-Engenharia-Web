using System.ComponentModel.DataAnnotations;

namespace Aula8b.Models
{
    public class User
    {
        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
