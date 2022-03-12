using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Aula6.Models
{
    [Table("student")]
    public partial class Student
    {
        [Key]
        [Column("number")]
        public int Number { get; set; }
        [Required]
        [Column("name")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("courseId")]
        public int? CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Students")]
        public virtual Course Course { get; set; }
    }
}
