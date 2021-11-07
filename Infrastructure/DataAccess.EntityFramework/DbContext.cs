using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=otus_db;User ID=postgres;password=123;");
        }

        #region [DbSets]

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourses> StudentCourses { get; set; }

        public DbSet<StudentLessons> StudentLessons { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(course =>
            {
                course.ToTable("course");
                course.HasKey(c => c.Id);

                course.HasMany(l => l.Lessons).WithOne(c => c.Course);
                course.HasMany(sc => sc.Students).WithOne(c => c.Course);

                course.HasIndex(c => c.Name).IsUnique();

                course.Property(c => c.Id).HasColumnName("id");
                course.Property(c => c.Name).HasColumnName("name");
                course.Property(c => c.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Lesson>(lesson =>
            {
                lesson.ToTable("lesson");
                lesson.HasKey(l => l.Id);

                lesson.Property(l => l.Id).HasColumnName("id");
                lesson.Property(l => l.Name).HasColumnName("name").IsRequired();
                lesson.Property(l => l.CourseId).HasColumnName("courseid").IsRequired();
            });

            modelBuilder.Entity<Student>(student =>
            {
                student.ToTable("student");
                student.HasKey(s => s.Id);

                student.HasMany(s => s.Courses).WithOne(sc => sc.Student);

                student.Property(s => s.Id).HasColumnName("id");
                student.Property(s => s.Fio).HasColumnName("fio").IsRequired();
            });

            modelBuilder.Entity<StudentCourses>(course =>
            {
                course.ToTable("studentcourses");
                course.HasKey(sc => sc.Id);

                course.HasMany(sc => sc.StudentLesson).WithOne(sl => sl.StudentCourse);

                course.Property(sc => sc.Id).HasColumnName("id");
                course.Property(sc => sc.CourseId).HasColumnName("courseid").IsRequired();
                course.Property(sc => sc.StudentId).HasColumnName("studentid").IsRequired();
            });

            modelBuilder.Entity<StudentLessons>(lesson =>
            {
                lesson.ToTable("studentlessons");
                lesson.HasKey(sl => sl.Id);

                lesson.HasOne(sl => sl.Lesson).WithMany(l => l.StudentLessons);

                lesson.Property(sl => sl.Id).HasColumnName("id");
                lesson.Property(sl => sl.StudentCourseId).HasColumnName("studentcourcesid").IsRequired();
                lesson.Property(sl => sl.LessonId).HasColumnName("lessonid").IsRequired();
                lesson.Property(sl => sl.HomeworkGrade).HasColumnName("homeworkgrade");
            });
        }
    }
}
