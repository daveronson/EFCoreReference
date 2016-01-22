using EFCoreRef.Model;
using Microsoft.Data.Entity;

namespace EFCoreRef.DAL
{
    public class EFCoreRefContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentID, x.CourseID });

            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseID);

            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server = DRONSONWK; Database = EFCoreRef; User Id = EFCoreRefDBO; Password = testing123;");
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

    }



}
