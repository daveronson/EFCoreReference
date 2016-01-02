using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.DAL;
using EFTesting.Model;
using EFTesting.App.Helper;

namespace EFTesting.App.CourseManagement
{
    public class CourseManagement
    {
        public static void List(EFTestingContext context)
        {
            int NumCourses;

            SCHelper.ClearConsole();


            NumCourses = context.Course.Count();
            if (NumCourses == 1)
            {
                Console.WriteLine("\nThere is {0} course in the database:", NumCourses);
            }
            else
            {
                Console.WriteLine("\nThere are {0} courses in the database:", NumCourses);
            }

            var courses = context.Course
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine("\tCourse: {0} - {1}", course.ID, course.Name);
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }

        public static void ListStudents(EFTestingContext context)
        {
            var Course = new Course();
            string ConsoleString = "";
            int CourseID;
            bool ValidCourseID;

            SCHelper.ClearConsole();

            Console.WriteLine("List all the students for a Course");
            Console.Write("Course ID: ");
            ConsoleString = Console.ReadLine();

            if (ConsoleString != "")
            {
                ValidCourseID = Int32.TryParse(ConsoleString, out CourseID);

                if (!ValidCourseID)
                {
                    Console.WriteLine("\t{0} is an invalid Course ID", ConsoleString);
                }

                var CourseQuery = context.Course
                    .Where(c => c.ID == CourseID)
                    .SingleOrDefault();

                var StudentCourses = context.Student
                    .Where(s => s.StudentCourses.Any(sc => sc.Course.ID == CourseID));

                if (CourseQuery != null)
                {
                    Console.WriteLine("\nThe course {0} has the following students:", CourseQuery.Name);
                    foreach (var Student in StudentCourses)
                    {
                        Console.WriteLine("\t{0} - {1}", Student.ID, Student.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Course is not in the database");
                }

                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
            }

        }

        public static void DeleteAll(EFTestingContext context)
        {
            SCHelper.ClearConsole();

            Console.Write("Removing all Courses from the database...");

            context.Course.Clear();
            context.SaveChanges();

            Console.WriteLine("done.");

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

        public static void Create(EFTestingContext context)
        {
            string _CourseName = "";

            SCHelper.ClearConsole();

            Console.WriteLine("Add a course:");
            Console.Write("Name: ");

            _CourseName = Console.ReadLine();

            if (_CourseName != "")
            {
                Console.Write("Adding course to the database...");
                var Course = new Course { Name = _CourseName };
                context.Course.Add(Course);
                context.SaveChanges();
                Console.WriteLine("done.");
                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
            }
        }

        public static void EnrollStudent(EFTestingContext context)
        {
            string ConsoleString = "";
            int StudentID = 0;
            int CourseID = 0;
            bool ValidStudentID = false;
            bool ValidCourseID = false;
            Console.WriteLine("Add Student to Course:");

            SCHelper.ClearConsole();

            Console.Write("Student ID: ");
            ConsoleString = Console.ReadLine();
            ValidStudentID = Int32.TryParse(ConsoleString, out StudentID);

            Console.Write("Course ID: ");
            ConsoleString = Console.ReadLine();
            ValidCourseID = Int32.TryParse(ConsoleString, out CourseID);

            if (!ValidStudentID || !ValidCourseID)
            {
                Console.WriteLine("Invalid Student ID or Course ID");
                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Trying to add \nStudent ID: {0} to Course ID: {1}",StudentID,CourseID);

            var StudentCourse = new StudentCourse { StudentID = StudentID, CourseID = CourseID };
            try
            {
                context.StudentCourse.Add(StudentCourse);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to add student {0} to course {1}", StudentID, CourseID);
                Console.WriteLine("Error: \n{0}\n{1}", e.Message,e.InnerException);
                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
                CourseMenuController.MenuHandler(context);
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }

    }
}
