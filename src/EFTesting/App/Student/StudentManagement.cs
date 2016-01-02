using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.DAL;
using EFTesting.Model;
using EFTesting.App.Helper;

namespace EFTesting.App.StudentManagement
{
    public class StudentManagement
    {
        public static List<Student> List()
        {
            
            using (var context = new EFTestingContext())
            {
                var students = context.Student
                    .ToList();
                return students;
            }
        }

        public static List<Course> ListCourses(int studentID)
        {
            using (var context = new EFTestingContext())
            {
                //Get courses where the studentID is in the StudentCourses join table
                var StudentCourses = context.Course
                        .Where(s => s.StudentCourses.Any(sc => sc.Student.ID == studentID))
                        .ToList();
                return StudentCourses;
            }
        }

        public static void DeleteAll(EFTestingContext context)
        {
            SCHelper.ClearConsole();

            Console.Write("Removing all Students from the database...");

            try
            {
                context.Student.Clear();
                context.SaveChanges();

                Console.WriteLine("done.");
            }
            catch
            {
                Console.WriteLine("error.");
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }

        public static void Create(EFTestingContext context)
        {
            string _StudentName = "";

            SCHelper.ClearConsole();

            Console.WriteLine("Add a student:");
            Console.Write("Name: ");

            _StudentName = Console.ReadLine();

            if (_StudentName != "")
            {
                Console.Write("Adding student to the database...");
                var Student = new Student { Name = _StudentName };
                try
                {
                    context.Student.Add(Student);
                    context.SaveChanges();
                    Console.WriteLine("done.");
                }
                catch
                {
                    Console.WriteLine("error.");
                }

                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
            }
        }

        public static void EnrollStudent(StudentCourse studentCourse)
        {
            if (studentCourse != null)
            {
                using (var context = new EFTestingContext())
                {
                    Student student = context.Student.FirstOrDefault(s => s.ID == studentCourse.StudentID);
                    Course course = context.Course.FirstOrDefault(c => c.ID == studentCourse.CourseID);
                    if (student != null && course != null)
                    {
                        //The student and course exist
                        StudentCourse CurrentStudentCourses = context.StudentCourse
                            .Where(sc => sc.StudentID == studentCourse.StudentID)
                            .Where(sc => sc.CourseID == studentCourse.CourseID)
                            .FirstOrDefault();
                        if (CurrentStudentCourses == null)
                        {
                            //The student isn't currently enrolled so we are good to add them to the course
                            context.StudentCourse.Add(studentCourse);
                            context.SaveChanges();
                        }
                    }                    
                }
            }
        }

    }
}
