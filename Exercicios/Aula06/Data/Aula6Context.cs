using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Aula6.Models;

#nullable disable

namespace Aula6.Data
{
    public partial class Aula6Context : DbContext
    {
        public Aula6Context()
        {
        }

        public Aula6Context(DbContextOptions<Aula6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("name=Aula6Context");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        //    modelBuilder.Entity<Student>(entity =>
        //    {
        //        entity.HasKey(e => e.Number)
        //            .HasName("PK__student__FD291E4007DF522B");

        //        entity.Property(e => e.Number).ValueGeneratedNever();

        //        entity.HasOne(d => d.Course)
        //            .WithMany(p => p.Students)
        //            .HasForeignKey(d => d.CourseId)
        //            .HasConstraintName("FK__student__courseI__25869641");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
