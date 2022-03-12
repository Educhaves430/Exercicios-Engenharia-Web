using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Aula6.Models
{
    [Table("course")]
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(150)]
        public string Name { get; set; }

        [InverseProperty(nameof(Student.Course))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
