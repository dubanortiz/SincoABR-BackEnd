using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SincoABR.Data.Models
{
    public partial class SincoABRContext : DbContext
    {
        public SincoABRContext()
        {
        }

        public SincoABRContext(DbContextOptions<SincoABRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assign> Assign { get; set; }
        public virtual DbSet<Classmates> Classmates { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Enroll> Enroll { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<StatePerson> StatePerson { get; set; }
        public virtual DbSet<TypePerson> TypePerson { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SincoABR;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Assign>(entity =>
            {
                entity.ToTable("assign");

                entity.HasIndex(e => new { e.CourseId, e.Teacher })
                    .HasName("UQ__assign__D62D0FD31DD8FF5B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Teacher).HasColumnName("teacher");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Assign)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_id");

                entity.HasOne(d => d.TeacherNavigation)
                    .WithMany(p => p.Assign)
                    .HasForeignKey(d => d.Teacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher");
            });

            modelBuilder.Entity<Classmates>(entity =>
            {
                entity.HasKey(e => new { e.Assign, e.Enrolls, e.Period })
                    .HasName("PK__classmat__09E6A873999A8902");

                entity.ToTable("classmates");

                entity.Property(e => e.Assign).HasColumnName("assign_");

                entity.Property(e => e.Enrolls).HasColumnName("enrolls");

                entity.Property(e => e.Period).HasColumnName("period_");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.AssignNavigation)
                    .WithMany(p => p.Classmates)
                    .HasForeignKey(d => d.Assign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assing_");

                entity.HasOne(d => d.EnrollsNavigation)
                    .WithMany(p => p.Classmates)
                    .HasForeignKey(d => d.Enrolls)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrolls");

                entity.HasOne(d => d.PeriodNavigation)
                    .WithMany(p => p.Classmates)
                    .HasForeignKey(d => d.Period)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("period_");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__course__FB82D9EA03E7D43A");

                entity.ToTable("course");

                entity.Property(e => e.IdCourse).HasColumnName("id_course");

                entity.Property(e => e.NameCourse)
                    .HasColumnName("name_course")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enroll>(entity =>
            {
                entity.ToTable("enroll");

                entity.HasIndex(e => new { e.Course, e.Student })
                    .HasName("UQ__enroll__D06FD44DDD2ADB7D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Course).HasColumnName("course_");

                entity.Property(e => e.Student).HasColumnName("student");

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.Enroll)
                    .HasForeignKey(d => d.Course)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Enroll)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasKey(e => e.IdPeriod)
                    .HasName("PK__period__1CDF3607BDAB104A");

                entity.ToTable("period");

                entity.Property(e => e.IdPeriod)
                    .HasColumnName("id_period")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamePeriod)
                    .HasColumnName("name_period")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonState)
                    .HasColumnName("person_state")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PersonType).HasColumnName("person_type");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersonStateNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.PersonState)
                    .HasConstraintName("person_state");

                entity.HasOne(d => d.PersonTypeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.PersonType)
                    .HasConstraintName("person_type");
            });

            modelBuilder.Entity<StatePerson>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__state_pe__12FD6C491E8D4D56");

                entity.ToTable("state_person");

                entity.Property(e => e.IdState)
                    .HasColumnName("id_state")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameState)
                    .HasColumnName("name_state")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePerson>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__type_per__C3F091E0A2ECF0F1");

                entity.ToTable("type_person");

                entity.Property(e => e.IdType)
                    .HasColumnName("id_type")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameType)
                    .HasColumnName("name_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
