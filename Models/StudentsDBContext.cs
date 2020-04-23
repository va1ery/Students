using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentsDB.Models
{
    public partial class StudentsDBContext : DbContext
    {
        public StudentsDBContext()
        {
        }

        public StudentsDBContext(DbContextOptions<StudentsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsAndClasses> StudentsAndClasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//       optionsBuilder.UseSqlServer("Data Source=LEO-ПК\\SQLEXPRESS;Initial Catalog=Students;Integrated security=True;ConnectRetryCount=0");
            optionsBuilder.UseSqlite("Data Source=Students.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AssignmentDescription).HasMaxLength(255);

                entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId)
                    .HasColumnName("ClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.DaysAndTimes).HasMaxLength(20);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Section).HasColumnName("Section №");

                entity.Property(e => e.Term).HasMaxLength(30);

                entity.Property(e => e.Units).HasMaxLength(30);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DepartmentChairperson).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentManager).HasMaxLength(30);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Instructors>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmailName).HasMaxLength(50);

                entity.Property(e => e.Extension).HasMaxLength(30);

                entity.Property(e => e.Instructor).HasMaxLength(50);

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ReportDesc).HasMaxLength(255);

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.ReportName).HasMaxLength(50);
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Major).HasMaxLength(50);

                entity.Property(e => e.ParentsNames).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.StateOrProvince).HasMaxLength(20);

                entity.Property(e => e.StudentNumber).HasMaxLength(30);
            });

            modelBuilder.Entity<StudentsAndClasses>(entity =>
            {
                entity.HasKey(e => e.StudentClassId)
                    .HasName("PK_Students And Classes_1");

                entity.ToTable("Students And Classes");

                entity.Property(e => e.StudentClassId)
                    .HasColumnName("StudentClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Grade).HasMaxLength(30);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentsAndClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students And Classes_Classes");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsAndClasses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Students And Classes_Students");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
