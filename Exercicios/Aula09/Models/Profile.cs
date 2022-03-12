using System;
using System.ComponentModel.DataAnnotations;

namespace Aula09.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
        // UserName of the User in the AspNetUsers
        public string UserName { get; set; }
    }
}
